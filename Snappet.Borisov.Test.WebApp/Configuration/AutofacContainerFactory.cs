using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Snappet.Borisov.Test.Domain;
using Snappet.Borisov.Test.Domain.Processing;
using Snappet.Borisov.Test.Domain.Reporting;
using Snappet.Borisov.Test.Infrastructure;

namespace Snappet.Borisov.Test.WebApp.Configuration
{
    public static class AutofacContainerFactory
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();

            // WebApi
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Program
            builder.RegisterType<ProgramConfiguration>().AsImplementedInterfaces().SingleInstance();

            // Configuration
            builder.RegisterType<HttpConfigurationFactory>().SingleInstance();

            // Domain
            builder.RegisterType<SubmittedAnswerProcessor>().AsImplementedInterfaces();
            builder.RegisterType<Students>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<OverviewReportGenerator>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<DateTimeProvider>().AsImplementedInterfaces().SingleInstance();

            // Infrastructure
            builder.RegisterType<SubmittedAnswerConverter>().AsImplementedInterfaces();
            builder.RegisterType<SubmittedAnswerProvider>().AsImplementedInterfaces();
            builder.RegisterType<SubmittedAnswerReader>().AsImplementedInterfaces();
            builder.RegisterType<StudentNameGenerator>().AsImplementedInterfaces().SingleInstance();

            return builder.Build();
        }
    }
}