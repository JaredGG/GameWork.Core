using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Core.Logging.Entries;

namespace GameWork.Core.Logging.Formatting
{
    public interface ILogFormatter : ILogFormatter<LogEntry>
    {
    }

    public interface ILogFormatter<TLogEntry>
        where TLogEntry : LogEntry
    {
        string Format(TLogEntry logEntry);
    }
}
