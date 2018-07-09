using System;
using System.Collections.Generic;
using System.Text;

namespace GameWork.Core.Logging
{
    public enum LogType
    {
        Fatal = LogLevel.Fatal,
        Error = LogLevel.Error,
        Warning = LogLevel.Warning,
        Info = LogLevel.Info,
        Debug = LogLevel.Debug,
        Verbose = LogLevel.Verbose
    }
}
