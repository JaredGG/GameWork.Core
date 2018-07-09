using System;

namespace GameWork.Core.Logging.PlatformAdaptors
{
    public interface ILogger
    {
        /// <summary>
        /// Tracing information and debugging minutae.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Verbose(string message, params object[] args);

        /// <summary>
        /// Information to help with debugging.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Debug(string message, params object[] args);
        
        /// <summary>
        /// Information tracking the usage of the system.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Issues that should be addressed but do not break gameplay/user experience.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Warning(string message, params object[] args);

        /// <summary>
        /// Issues that break gameplay/user experience.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Issues that break gameplay/user experience.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Error(Exception exception, string message = null, params object[] args);

        /// <summary>
        /// Issues that would/should crash the game.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Fatal(string message, params object[] args);

        /// <summary>
        /// Issues that would/should crash the game.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Fatal(Exception exception, string message = null, params object[] args);

        /// <summary>
        /// Can be used instead of a direct method reference.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Log(LogType type, string message, params object[] args);

        /// <summary>
        /// Level above of which to log.
        /// </summary>
        LogLevel LogLevel { get; set; }
    }
}