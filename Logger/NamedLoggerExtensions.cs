using System;

namespace Logger
{
    public static class NamedLoggerExtensions
    {
        public static void LogUser(this ILogger logger, string message, decimal userId)
        {
            var logEntry = new LogEntry
            {
                Message = message,
                LogLevel = LogLevel.Information,
                Properties = { {"userId", userId } }
            };

            logger.Log(logEntry);
        }

        public static void LogOperation(this ILogger logger, string operation, DateTime start, double duration, int amount = 0, string additional = "")
        {
            var logEntry = new LogEntry
            {
                LogLevel = LogLevel.Information,
                Properties = { { "name", operation }, { "start_date", start }, { "duration", duration }, { "amount", amount }, { "additional", additional } }
            };

            logger.Log(logEntry);
        }
    }
}
