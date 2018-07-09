using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameWork.Core.Logging.Entries;

namespace GameWork.Core.Logging.Formatting
{
    public class TickLogFormatter : ILogFormatter<TickLogEntry>
    {
        public string Format(TickLogEntry logEntry)
        {
            return $"{logEntry.TimeStamp:yyyy-MM-dd HH:mm:ss.fff} " +
                   $"{logEntry.Tick} " +
                   $"[{LogFormatter.LogTypeStrings[logEntry.LogType]}] " +
                   $"{(logEntry.Args.Any() ? string.Format(logEntry.Message, logEntry.Args) : logEntry.Message)}" +
                   $"{(logEntry.Exception == null ? "" : $" {logEntry.Exception.Message}\n{logEntry.Exception.StackTrace}")}";
        }
    }
}
