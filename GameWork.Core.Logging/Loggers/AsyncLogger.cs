using System;
using System.Collections.Concurrent;
using System.Threading;
using GameWork.Core.Logging.Entries;
using GameWork.Core.Logging.Factories;
using GameWork.Core.Logging.Formatting;
using GameWork.Core.Logging.PlatformAdaptors;

namespace GameWork.Core.Logging.Loggers
{

    public class AsyncLogger : AsyncLogger<LogEntry>
    {
        public AsyncLogger(ILogWriter writer) : base(writer, new LogFormatter(), new LogFactory())
        {
        }

        public AsyncLogger(ILogWriter logWriter, ILogFormatter formatter) : base(logWriter, formatter, new LogFactory())
        {
        }
    }

    public class AsyncLogger<TLogEntry> : Logger<TLogEntry>, IDisposable
        where TLogEntry : LogEntry
    {
        private readonly ConcurrentQueue<TLogEntry> _logWriteQueue = new ConcurrentQueue<TLogEntry>();
        private readonly ManualResetEventSlim _writeEvent = new ManualResetEventSlim(false);
        private readonly CancellationTokenSource _cancellation = new CancellationTokenSource();
        
        public AsyncLogger(ILogWriter writer, ILogFormatter<TLogEntry> formatter, ILogFactory<TLogEntry> factory) : base(writer, formatter, factory)
        {
            var thread = new Thread(Worker);
            thread.Start();
        }

        ~AsyncLogger()
        {
            if (!_cancellation.Token.IsCancellationRequested)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _cancellation.Cancel();
            _writeEvent.Dispose();
            _cancellation.Dispose();
        }

        public void Flush()
        {
            while (!_logWriteQueue.IsEmpty)
            {
                if (!_writeEvent.IsSet)
                {
                    _writeEvent.Set();
                }
            }
        }
        
        protected override void TryLog(LogType logType, string message, object[] args, Exception exception = null)
        {
            if (IsLogLevelEnabled(logType))
            {
                var logEntry = _factory.Create(logType, message, args, exception);
                _logWriteQueue.Enqueue(logEntry);
                _writeEvent.Set();
            }
        }

        private void Worker()
        {
            while (!_cancellation.IsCancellationRequested)
            {
                _writeEvent.Wait(_cancellation.Token);

                while (_logWriteQueue.TryDequeue(out var logEntry))
                {
                    var formattedLogEntry = _formatter.Format(logEntry);
                    _writer.WriteLine(formattedLogEntry);
                }

                _writeEvent.Reset();
            }
        }
    }
}
