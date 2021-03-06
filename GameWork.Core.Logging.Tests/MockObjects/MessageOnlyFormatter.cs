﻿using System;
using System.Collections.Generic;
using System.Text;
using GameWork.Core.Logging.Entries;
using GameWork.Core.Logging.Formatting;

namespace GameWork.Core.Logging.Tests.MockObjects
{
    public class MessageOnlyFormatter : ILogFormatter
    {
        public string Format(LogEntry logEntry)
        {
            return logEntry.Message;
        }
    }
}
