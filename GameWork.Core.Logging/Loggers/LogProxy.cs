using GameWork.Core.Logging.PlatformAdaptors;

namespace GameWork.Core.Logging.Loggers
{
    /// <summary>
    /// Static logging utility class.
    /// </summary>
    public static class LogProxy
    {
        private static ILogger _logger;

        public static LogLevel LogLevel
        {
            get => _logger.LogLevel;
            set => _logger.LogLevel = value;
        }

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static void Verbose(string message, params object[] args)
        {
            _logger.Verbose(message, args);
        }

        public static void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        public static void Info(string message, params object[] args)
        {
            _logger.Info(message);
        }

        public static void Warning(string message, params object[] args)
        {
            _logger.Warning(message, args);
        }

        public static void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public static void Fatal(string message, params object[] args)
        {
            _logger.Fatal(message, args);
        }

        public static void Log(LogType logType, string message, params object[] args)
        {
            _logger.Log(logType, message, args);
        }
    }
}
