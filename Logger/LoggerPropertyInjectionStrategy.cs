using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using System.ComponentModel;

namespace Logger
{

    public class LoggerPropertyInjectionStrategy : BuilderStrategy
    {
        private readonly IUnityContainer _container;

        public LoggerPropertyInjectionStrategy(IUnityContainer container)
        {
            _container = container;
        }

        public override void PreBuildUp(IBuilderContext context)
        {
            base.PreBuildUp(context);

            if (!_container.IsRegistered<ILoggerFactory>())
            {
                return;
            }

            var loggerProperties = TypeDescriptor.GetProperties(context.BuildKey.Type);
            foreach (PropertyDescriptor property in loggerProperties)
            {
                if (property != null && typeof(ILogger).IsAssignableFrom(property.PropertyType))
                {
                    InjectLogger(property, context);
                }
            }
        }

        private void InjectLogger(PropertyDescriptor loggerProperty, IBuilderContext context)
        {
            var loggerConfigurationOptions = new LoggerConfigurationOptions();
            var loggerAttribute = (LoggerAttribute)loggerProperty.Attributes[typeof(LoggerAttribute)];
            loggerConfigurationOptions.Category = loggerAttribute != null ? loggerAttribute.Category : Category.Default;

            if (loggerAttribute != null && !string.IsNullOrEmpty(loggerAttribute.Name))
            {
                loggerConfigurationOptions.Name = loggerAttribute.Name;
            }
            else
            {
                loggerConfigurationOptions.Name = context.BuildKey.Type.Name;
            }

            var loggerFactory = _container.Resolve<ILoggerFactory>();
            var loggerInstance = loggerFactory.CreateLogger(loggerConfigurationOptions);
            loggerProperty.SetValue(context.Existing, loggerInstance);
        }
    }
}
