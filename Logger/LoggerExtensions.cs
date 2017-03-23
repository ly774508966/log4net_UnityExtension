using System;

namespace Logger
{
    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string message)
        {
            FilteredLogSafe(logger, LogLevel.Debug, null, message, null);
        }

        public static void Information(this ILogger logger, string message)
        {
            FilteredLogSafe(logger, LogLevel.Information, null, message, null);
        }

        public static void Warning(this ILogger logger, string message)
        {
            FilteredLogSafe(logger, LogLevel.Warning, null, message, null);
        }

        public static void Error(this ILogger logger, string message)
        {
            FilteredLogSafe(logger, LogLevel.Error, null, message, null);
        }

        public static void Fatal(this ILogger logger, string message)
        {
            FilteredLogSafe(logger, LogLevel.Fatal, null, message, null);
        }

        public static void Debug(this ILogger logger, Exception exception, string message)
        {
            FilteredLogSafe(logger, LogLevel.Debug, exception, message, null);
        }

        public static void Information(this ILogger logger, Exception exception, string message)
        {
            FilteredLogSafe(logger, LogLevel.Information, exception, message, null);
        }

        public static void Warning(this ILogger logger, Exception exception, string message)
        {
            FilteredLogSafe(logger, LogLevel.Warning, exception, message, null);
        }

        public static void Error(this ILogger logger, Exception exception, string message)
        {
            FilteredLogSafe(logger, LogLevel.Error, exception, message, null);
        }

        public static void Fatal(this ILogger logger, Exception exception, string message)
        {
            FilteredLogSafe(logger, LogLevel.Fatal, exception, message, null);
        }

        public static void Debug(this ILogger logger, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Debug, null, format, args);
        }

        public static void Information(this ILogger logger, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Information, null, format, args);
        }

        public static void Warning(this ILogger logger, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Warning, null, format, args);
        }

        public static void Error(this ILogger logger, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Error, null, format, args);
        }

        public static void Fatal(this ILogger logger, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Fatal, null, format, args);
        }

        public static void Debug(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Debug, exception, format, args);
        }

        public static void Information(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Information, exception, format, args);
        }

        public static void Warning(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Warning, exception, format, args);
        }

        public static void Error(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Error, exception, format, args);
        }

        public static void Fatal(this ILogger logger, Exception exception, string format, params object[] args)
        {
            FilteredLogSafe(logger, LogLevel.Fatal, exception, format, args);
        }

        private static void FilteredLogSafe(ILogger logger, LogLevel level, Exception exception, string format, object[] objects)
        {
            if (logger != null)
            {
                FilteredLog(logger, level, exception, format, objects);
            }
        }

        private static void FilteredLog(ILogger logger, LogLevel level, Exception exception, string format, object[] objects)
        {
            if (logger.IsEnabled(level))
            {
                logger.Log(level, exception, format, objects);
            }
        }
    }
}
