using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Core.Logging.Entries;

namespace GameWork.Core.Logging.Factories
{
    public class LogFactory : ILogFactory
    {
        public LogEntry Create(LogType logType, string message, object[] args, Exception exception = null)
        {
            return new LogEntry
            {
                LogType = logType,
                TimeStamp = DateTime.UtcNow,
                Message = message,
                Args = args,
                Exception = exception
            };
        }
    }
}
