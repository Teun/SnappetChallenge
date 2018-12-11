using Snappet.Repository;
using System;
using System.Web.Http;
using Unity;

namespace Snappet.WebAPI.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            ContainerBootStrapper.RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}