using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using GameWork.Core.Logging.PlatformAdaptors;

namespace GameWork.Core.Logging.Tests.MockObjects
{
    public class LogQueueWriter : ILogWriter
    {
        public ConcurrentQueue<string> Lines = new ConcurrentQueue<string>();

        public void WriteLine(string line)
        {
            Lines.Enqueue(line);
        }
    }
}
