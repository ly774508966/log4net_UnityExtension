using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Logger
{
    public class LoggerContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ILoggerFactory, Log4NetLoggerFactory>();
            Context.Strategies.Add(new LoggerPropertyInjectionStrategy(Container), UnityBuildStage.Initialization);
        }
    }
}
