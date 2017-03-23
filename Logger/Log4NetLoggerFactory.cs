using System.Collections.Generic;
using log4net;
using log4net.Config;

namespace Logger
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public static void Configure()
        {
            XmlConfigurator.Configure();
        }

        public ILogger CreateLogger(LoggerConfigurationOptions options)
        {
            var log = LogManager.GetLogger(options.Name);
            var properties = new Dictionary<string, object> {{"category", options.Category}};
            return new Log4NetLogger(log, properties);
        }
    }
}