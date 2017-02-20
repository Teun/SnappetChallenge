using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Logging;
using NServiceBus.Persistence;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = NHibernate.Cfg.Environment;

namespace Snappet.Test.Infrastructure.NServiceBus
{
    public abstract class EndpointBase
    {
        private readonly bool _installOnly;

        protected EndpointBase(string endpointName, bool installOnly)
        {
            EndpointName = endpointName;
            _installOnly = installOnly;
        }

        public string EndpointName { get; }
        
        private EndpointConfiguration GetConfiguration()
        { 
            // General configuration
            var endpointConfiguration = new EndpointConfiguration(EndpointName);
            endpointConfiguration.UseSerialization<JsonSerializer>();
            
            // Logging
            LogManager.Use<NLogFactory>();

            // Persistence
            var nhConfiguration = new Configuration();
            nhConfiguration.SetProperty(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            nhConfiguration.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.Sql2008ClientDriver");
            nhConfiguration.SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect");
            nhConfiguration.SetProperty(Environment.ConnectionString, GetConnectionString($"Snappet.Endpoint.{EndpointName}"));

            PersistenceExtensions<NHibernatePersistence> persistence = endpointConfiguration.UsePersistence<NHibernatePersistence>();
            persistence.UseConfiguration(nhConfiguration);

            // Transport
            endpointConfiguration.UseTransport<SqlServerTransport>()
                .ConnectionString(GetConnectionString("Snappet.NServiceBus.SqlTransport"));
            endpointConfiguration.EnableOutbox();
            
            endpointConfiguration.UseContainer<AutofacBuilder>();
            
            // Error Queue
            endpointConfiguration.SendFailedMessagesTo("Snappet-Error");

            // Concurrency
            int maxConcurrency;
            if (int.TryParse(ConfigurationManager.AppSettings["MaxConcurrency"], out maxConcurrency))
            {
                endpointConfiguration.LimitMessageProcessingConcurrencyTo(maxConcurrency);
            }

            // Container
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            IContainer container = builder.Build();
            endpointConfiguration.UseContainer<AutofacBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });

            // Conventions
            ConfigureConventions(endpointConfiguration);
            
            // Allow custom configurations
            Configure(endpointConfiguration);

            if (_installOnly)
            {
                endpointConfiguration.EnableInstallers();
            }
            else
            {
                persistence.DisableSchemaUpdate();
            }

            return endpointConfiguration;
        }

        private static void ConfigureConventions(EndpointConfiguration configuration)
        {
            configuration.Conventions()
                .DefiningCommandsAs(t => !t.IsAbstract && IsInNamespace(t) && t.Name.EndsWith("Command"))
                .DefiningEventsAs(t => (!t.IsAbstract || t.IsInterface) && IsInNamespace(t) && t.Name.EndsWith("Event"))
                .DefiningMessagesAs(t => !t.IsAbstract && IsInNamespace(t) && t.Name.EndsWith("Message"));
        }

        private static bool IsInNamespace(Type type)
        {
            return type.Namespace != null && type.Namespace.StartsWith("Snappet.");
        }

        protected abstract void ConfigureContainer(ContainerBuilder builder);
        protected abstract void Configure(EndpointConfiguration config);

        private static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[$"{connectionStringName}-{System.Environment.MachineName}"].ConnectionString;
        }


        public IEndpointInstance BusInstance { get; private set; }

        public async Task Run()
        {
            IEndpointInstance busInstance = await Endpoint.Start(GetConfiguration()).ConfigureAwait(false);
            if (!_installOnly)
            {
                BusInstance = busInstance;
            }
        }

        public Task Stop()
        {
            return BusInstance?.Stop() ?? Task.CompletedTask;
        }
    }
}