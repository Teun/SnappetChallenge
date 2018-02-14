using Autofac;
using Autofac.Integration.WebApi;
using Snappet.ServiceRegistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.SessionState;

namespace Snappet.REST.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // activate session in READ ONLY as we just use it to check the user is logged/authorized [ To optemize web api performance]
            System.Web.HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.ReadOnly);
            // DI - dependency injection
            // Autofac
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            // Register all api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).AsSelf();
            // Register business objects            
            builder = ServiceTypeRegistry.Register(builder);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
