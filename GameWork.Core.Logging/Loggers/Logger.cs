using System;
using GameWork.Core.Logging.Entries;
using GameWork.Core.Logging.Factories;
using GameWork.Core.Logging.Formatting;
using GameWork.Core.Logging.PlatformAdaptors;

namespace GameWork.Core.Logging.Loggers
{
    public class Logger : Logger<LogEntry>
    {
        public Logger(ILogWriter logWriter) : base(logWriter, new LogFormatter(), new LogFactory())
        {
        }

        public Logger(ILogWriter logWriter, ILogFormatter formatter) : base(logWriter, formatter, new LogFactory())
        {
        }
    }

    public class Logger<TLogEntry> : ILogger
        where TLogEntry : LogEntry
    {
        protected readonly ILogWriter _writer;
        protected readonly ILogFormatter<TLogEntry> _formatter;
        protected readonly ILogFactory<TLogEntry> _factory;

        public LogLevel LogLevel { get; set; } = LogLevel.Debug;

        public Logger(ILogWriter writer, ILogFormatter<TLogEntry> formatter, ILogFactory<TLogEntry> factory)
        {
            _writer = writer;
            _formatter = formatter;
            _factory = factory;
        }

        public void Verbose(string message, params object[] args)
        {
            TryLog(LogType.Verbose, message, args);
        }

        public void Debug(string message, params object[] args)
        {
            TryLog(LogType.Debug, message, args);
        }

        public void Info(string message, params object[] args)
        {
            TryLog(LogType.Info, message, args);
        }

        public void Warning(string message, params object[] args)
        {
            TryLog(LogType.Warning, message, args);
        }

        public void Error(string message, params object[] args)
        {
            TryLog(LogType.Error, message, args);
        }

        public void Error(Exception exception, string message = null, params object[] args)
        {
            TryLog(LogType.Fatal, message, args, exception);
        }

        public void Fatal(string message, params object[] args)
        {
            TryLog(LogType.Fatal, message, args);
        }

        public void Fatal(Exception exception, string message = null, params object[] args)
        {
            TryLog(LogType.Fatal, message, args, exception);
        }

        public void Log(LogType type, string message, params object[] args)
        {
            TryLog(type, message, args);
        }

        protected virtual void TryLog(LogType logType, string message, object[] args, Exception exception = null)
        {
            if (IsLogLevelEnabled(logType))
            {
                var entry = _factory.Create(logType, message, args, exception);
                var formattedLog = _formatter.Format(entry);
                _writer.WriteLine(formattedLog);
            }
        }

        protected bool IsLogLevelEnabled(LogType logType) => (int) logType <= (int) LogLevel;
    }
}