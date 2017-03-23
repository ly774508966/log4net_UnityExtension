using System;
using System.Collections;
using log4net;
using log4net.Core;

namespace Logger
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _logger;

        private readonly IDictionary _instanceProperties;

        public Log4NetLogger(ILog logger)
        {
            _logger = logger;
        }

        public Log4NetLogger(ILog logger, IDictionary properties) : this(logger)
        {
            _instanceProperties = properties;
        }

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return _logger.IsDebugEnabled;
                case LogLevel.Information:
                    return _logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return _logger.IsWarnEnabled;
                case LogLevel.Error:
                    return _logger.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _logger.IsFatalEnabled;
                default:
                    return false;
            }
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            var message = args != null ? string.Format(format, args) : format;
            Log(new LogEntry{LogLevel = level, Exception = exception, Message = message});
        }

        protected LoggingEvent CreateLoggingEvent(Level level, object message, Exception exception)
        {
            var type = GetType();
            var repository = _logger.Logger.Repository;
            var name = _logger.Logger.Name;

            var loggingEvent = new LoggingEvent(type, repository, name, level, message, exception);
            return loggingEvent;
        }

        private static void MergeProperties(LoggingEvent loggingEvent, IDictionary properties)
        {
            if (properties != null)
            {
                foreach (var key in properties.Keys)
                {
                    loggingEvent.Properties[key.ToString()] = properties[key];
                }
            }
        }

        public void Log(LogEntry logEntry)
        {
            var level = ConvertLevel(logEntry.LogLevel);
            var loggingEvent = CreateLoggingEvent(level, logEntry.Message, logEntry.Exception);
            MergeProperties(loggingEvent, _instanceProperties);
            MergeProperties(loggingEvent, logEntry.Properties);
            _logger.Logger.Log(loggingEvent);
        }

        private Level ConvertLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return Level.Debug;
                case LogLevel.Information:
                    return Level.Info;
                case LogLevel.Warning:
                    return Level.Warn;
                case LogLevel.Error:
                    return Level.Error;
                case LogLevel.Fatal:
                    return Level.Fatal;
                default:
                    return Level.All;
            }
        }
    }
}
