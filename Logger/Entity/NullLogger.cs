using System;

namespace Logger
{
    /// <summary>
    /// Null logger implementation. Write nothing.
    /// </summary>
    public class NullLogger : ILogger
    {
        private static readonly ILogger _instance = new NullLogger();

        public static ILogger Instance
        {
            get { return _instance; }
        }

        public bool IsEnabled(LogLevel level)
        {
            return false;
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
        }

        public void Log(LogEntry logEntry)
        {
            
        }
    }
}
