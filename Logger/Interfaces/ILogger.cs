using System;

namespace Logger
{
    /// <summary>
    /// Base interface for logging, loggers must implement this interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Check what LogLevel enabled in this logger
        /// </summary>
        /// <param name="level">LogLevel enum <see cref="LogLevel"/> for check</param>
        /// <returns></returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// Log action. Write message to logging output.
        /// </summary>
        /// <param name="level">LogLevel enum <see cref="LogLevel"/></param>
        /// <param name="exception">Occurred exception for logging</param>
        /// <param name="format">Message string with <see cref="string.Format(string,object)"/></param>
        /// <param name="args">Additional message arguments</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);

        /// <summary>
        /// Log action. Write message to logging output.
        /// </summary>
        /// <param name="logEntry">Contains all necessary information for logging <see cref="LogEntry"/></param>
        void Log(LogEntry logEntry);
    }
}
