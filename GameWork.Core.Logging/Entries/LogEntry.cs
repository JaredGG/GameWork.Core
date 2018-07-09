using System;

namespace GameWork.Core.Logging.Entries
{
    public class LogEntry
    {
        public LogType LogType { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public object[] Args { get; set; }
    }
}
