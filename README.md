# UnityContainerExtension for log4net.

1. Add LoggerContainerExtension in your UnityConfig RegisterComponents

```sh
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();

            // logger extension
            container.AddExtension(new LoggerContainerExtension());

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
```
2. Call  XmlConfigurator configure in Startup 


```sh
  public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            UnityConfig.RegisterComponents(httpConfig);
            ConfigureWebApi(httpConfig);
            app.UseWebApi(httpConfig);
            Log4NetLoggerFactory.Configure();
        }
    }
```


Use inside your code like this


```sh
        [Logger(Name = "UserLog", Category = Category.UserAction)]
        public ILogger Logger { get; set; }

        [Logger(Name = "OperationLog", Category = Category.ReportAction)]
        public ILogger OperationLog { get; set; }
```

or resolve it manually


```sh
            var loggerFactory = UnityConfig.UnityContainer.Resolve<ILoggerFactory>();
            ILogger _logger = loggerFactory.CreateLogger(new LoggerConfigurationOptions { Name = "UserLog", Category = Category.UserAction });
```



Example for Web.config


```sh
    <appender name="UserLog" type="log4net.Appender.RollingFileAppender, log4net">
      <lockingmodel type="log4net.Appender.FileAppender+MinimalLock" />
      <param name="File" value="C:\\Logs\\UserLog" />
      <param name="AppendToFile" value="true" />
      <param name="RollingStyle" value="Date" />
      <param name="DatePattern" value="yyyyMMdd.c\sv" />
      <param name="StaticLogFileName" value="false" />
      <param name="MaxSizeRollBackups" value="60" />
      <layout type="log4net.Layout.PatternLayout">
        <param name="ConversionPattern" value="%d;[%t];%-5p;%property{category};%property{userId};%identity;%m%n" />
      </layout>
    </appender>
    <appender name="OperationLog" type="log4net.Appender.RollingFileAppender, log4net">
      <lockingmodel type="log4net.Appender.FileAppender+MinimalLock" />
      <param name="File" value="C:\\Logs\\OperationLog" />
      <param name="AppendToFile" value="true" />
      <param name="RollingStyle" value="Date" />
      <param name="DatePattern" value="yyyyMMdd.c\sv" />
      <param name="StaticLogFileName" value="false" />
      <param name="MaxSizeRollBackups" value="60" />
      <layout type="log4net.Layout.PatternLayout">
        <param name="ConversionPattern" value="%d;[%t];%-5p;%property{category};%identity;%property{name};%property{start_date};%property{duration};%property{amount};%property{additional};%m%n" />
      </layout>
    </appender>
    <logger name="UserLog">
      <level value="INFO" />
      <appender-ref ref="UserLog" />
    </logger>
    <logger name="OperationLog">
      <level value="INFO" />
      <appender-ref ref="OperationLog" />
    </logger>
```
