using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Common.Logging;
using Snappet.Data.Interfaces;
using Snappet.Reports;
using Snappet.TestData.Repositories;
using Snappet.TestData.Sources;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Dashboard.App_Start
{
    public class IocConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterType<SimpleReportFactory>().As<IReportFactory>();

            RegisterMockDependencies(builder);

            builder.Register((c) => LogManager.GetLogger("Dashboard")).SingleInstance();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterMockDependencies(ContainerBuilder builder)
        {
            builder.Register<ITestDataSource>((c) => new ResourceFileDataSource("Snappet.TestData.BaseSet.work.json")).SingleInstance();
            builder.RegisterType<ExerciseMockRepository>().As<IExerciseRepository>().SingleInstance();
        }
    }
}