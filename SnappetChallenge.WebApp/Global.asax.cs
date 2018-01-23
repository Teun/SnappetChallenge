using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using NLog;
using SnappetChallenge.Repositories.JSON;
using SnappetChallenge.Services;

namespace SnappetChallenge.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<WorkResultRepository>().As<IWorkResultRepository>().InstancePerLifetimeScope();
            builder.RegisterType<WorkResultService>().As<IWorkResultService>().InstancePerLifetimeScope();
            var container = builder.Build();
            container.BeginLifetimeScope();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            Exception exception = Server.GetLastError();
            logger.Error(exception,"Error occured at " + DateTime.Now);
            Server.ClearError();
            //Response.Redirect("~/Error");
        }
    }
}
