using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Data.Implementations;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Web
{
    internal partial class Startup
    {
        protected void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            ConfigureContainer(builder);

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TopStudentsQuery>().As<ITopStudentsQuery>().InstancePerRequest();
            builder.RegisterType<DaySummaryQuery>().As<IDaySummaryQuery>().InstancePerRequest();
        }
    }
}
