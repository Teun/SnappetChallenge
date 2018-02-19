using Snappet.Infrastructure.DAL.Contract;
using Snappet.Infrastructure.DAL.Implementation;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Snappet.Presentation
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IMemoryReadOnlyRepository, MemoryReadOnlyRepository>(new ContainerControlledLifetimeManager());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}