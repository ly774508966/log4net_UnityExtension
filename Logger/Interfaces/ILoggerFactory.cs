namespace Logger
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(LoggerConfigurationOptions options);
    }
}
