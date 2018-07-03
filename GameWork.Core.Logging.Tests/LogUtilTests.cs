using System;
using System.Linq;
using GameWork.Core.Logging.Tests.MockObjects;
using Xunit;

namespace GameWork.Core.Logging.Tests
{
    public class LogUtilTests
    {
        [Fact]
        public void LogsInfo()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Info;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Info));
        }

        [Fact]
        public void LogsDebug()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Debug;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Debug));
        }

        [Fact]
        public void LogsWarning()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Warning;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Warning));
        }

        [Fact]
        public void LogsErrorMessage()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Error;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Error));
            Assert.Contains(logger.Messages, m => m.Message != null);
        }

        [Fact]
        public void LogsErrorException()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Error;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Error));
            Assert.Contains(logger.Messages, m => m.Exception != null);
        }

        [Fact]
        public void LogsFatalMessage()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Fatal;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Fatal));
            Assert.Contains(logger.Messages, m => m.Message != null);
        }

        [Fact]
        public void LogsFatalException()
        {
            // Arrange
            var logger = new MockLogger();
            LogUtil.SetLogger(logger);
            LogUtil.LogLevel = LogLevel.Fatal;

            // Act
            LogAll();

            // Assert
            Assert.True(logger.Messages.All(m => m.LogLevel <= LogLevel.Fatal));
            Assert.Contains(logger.Messages, m => m.Exception != null);
        }

        private void LogAll()
        {
            LogUtil.Info("info");
            LogUtil.Debug("debug");
            LogUtil.Warning("warning");
            LogUtil.Error("error");
            LogUtil.Error(new Exception("error"));
            LogUtil.Fatal("fatal");
            LogUtil.Fatal(new Exception("fatal"));
        }
    }
}
