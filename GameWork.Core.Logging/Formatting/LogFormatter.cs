using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameWork.Core.Logging.Entries;

namespace GameWork.Core.Logging.Formatting
{
    public class LogFormatter : ILogFormatter
    {
        public static readonly Dictionary<LogType, string> LogTypeStrings = new Dictionary<LogType, string>
        {
            {LogType.Verbose, "VRB"},
            {LogType.Debug, "DBG"},
            {LogType.Info, "INF"},
            {LogType.Warning, "WRN"},
            {LogType.Error, "ERR"},
            {LogType.Fatal, "FTL"}
        };

        public string Format(LogEntry logEntry)
        {
            return $"{logEntry.TimeStamp:yyyy-MM-dd HH:mm:ss.fff} " +
                   $"[{LogTypeStrings[logEntry.LogType]}] " +
                   $"{(logEntry.Args.Any() ? string.Format(logEntry.Message, logEntry.Args) : logEntry.Message)}" +
                   $"{(logEntry.Exception == null ? "" : $" {logEntry.Exception.Message}\n{logEntry.Exception.StackTrace}")}";
        }
    }
}