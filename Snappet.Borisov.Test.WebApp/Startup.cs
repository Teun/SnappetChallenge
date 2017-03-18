using Autofac;
using Microsoft.Owin;
using Owin;
using Snappet.Borisov.Test.Domain.Processing;
using Snappet.Borisov.Test.WebApp;
using Snappet.Borisov.Test.WebApp.Configuration;

[assembly: OwinStartup(typeof(Startup))]

namespace Snappet.Borisov.Test.WebApp
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void Configuration(IAppBuilder appBuilder)
        {
            var container = AutofacContainerFactory.Create();

            container.Resolve<IProcessSubmittedAnswers>().Process();

            var config = container.Resolve<HttpConfigurationFactory>().Create();

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            appBuilder.UseWebApi(config);
        }
    }
}