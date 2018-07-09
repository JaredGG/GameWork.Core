using System;
using GameWork.Core.Logging.Entries;

namespace GameWork.Core.Logging.Factories
{
    public interface ILogFactory : ILogFactory<LogEntry>
    {
    }

    public interface ILogFactory<TLogEntry>
        where TLogEntry : LogEntry
    {
        TLogEntry Create(LogType logType, string message, object[] args, Exception exception = null);
    }
}
