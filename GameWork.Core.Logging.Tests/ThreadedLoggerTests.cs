using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GameWork.Core.Logging.Entries;
using GameWork.Core.Logging.Formatting;
using GameWork.Core.Logging.Loggers;
using GameWork.Core.Logging.Tests.MockObjects;
using Xunit;

namespace GameWork.Core.Logging.Tests
{
    public class ThreadedLoggerTests
    {
        [Theory]
        [InlineData(LogType.Debug, "test debug log")]
        [InlineData(LogType.Info, "test info log")]
        [InlineData(LogType.Warning, "test warning log")]
        [InlineData(LogType.Error, "test error log")]
        [InlineData(LogType.Fatal, "test fatal log")]
        public void DoesLog(LogType logType, string message)
        {
            // Arrange
            var writer = new LogQueueWriter();
            var formatter = new LogFormatter();
            using (var logger = new AsyncLogger(writer, formatter))
            {

                // Act
                logger.Log(logType, message);

                while (!writer.Lines.Any()) { }

                logger.Flush();
            }

            // Assert
            Assert.Single(writer.Lines);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(9)]
        [InlineData(1000)]
        [InlineData(35621)]
        public void DoesLogInOrder(int count)
        {
            // Arrange
            var writer = new LogQueueWriter();
            var formatter = new MessageOnlyFormatter();
            using (var logger = new AsyncLogger(writer, formatter))
            {
                // Act
                for (var i = 0; i < count; i++)
                {
                    logger.Info(i.ToString());
                }

                while (!writer.Lines.Any()) { }

                logger.Flush();
            }

            // Assert
            Assert.Equal(count, writer.Lines.Count);

            var logLines = writer.Lines.Select(int.Parse).ToList();
            for (var i = 0; i < logLines.Count - 1; i++)
            {
                Assert.Equal(logLines[i], logLines[i + 1] - 1);
            }
        }

        [Theory]
        [InlineData(LogType.Debug, "test debug log")]
        [InlineData(LogType.Info, "test info log")]
        [InlineData(LogType.Warning, "test warning log")]
        [InlineData(LogType.Error, "test error log")]
        [InlineData(LogType.Fatal, "test fatal log")]
        public void DoesFormat(LogType logType, string message)
        {
            // Arrange
            var writer = new LogQueueWriter();
            var formatter = new TypeMessageFormatter();
            using (var logger = new AsyncLogger(writer, formatter))
            {
                // Act
                logger.Log(logType, message);

                while (!writer.Lines.Any()) { }

                logger.Flush();
            }

            // Assert
            var originalLog = writer.Lines.Single();
            var duplicateEntry = new LogEntry
            {
                LogType = logType,
                Message = message
            };
            var duplicateLog = formatter.Format(duplicateEntry);

            Assert.Equal(originalLog, duplicateLog);
        }
    }
}
