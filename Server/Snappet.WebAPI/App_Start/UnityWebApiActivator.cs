using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Snappet.WebAPI.Unity;
using Snappet.Common.BusinessLogic;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Snappet.WebApi.UnityWebApiActivator.UnityWebApiActivator), nameof(Snappet.WebApi.UnityWebApiActivator.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Snappet.WebApi.UnityWebApiActivator.UnityWebApiActivator), nameof(Snappet.WebApi.UnityWebApiActivator.UnityWebApiActivator.Shutdown))]

namespace Snappet.WebApi.UnityWebApiActivator
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts. I have used MEF and Unity feature to resolve type depedency.
        /// </summary>
        public static void Start() 
        {
            UnityConfigurations unity = new UnityConfigurations();
            IUnityContainer _container = unity.UnityResolver();
            var resolver = new UnityDependencyResolver(_container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            _container.RegisterInstance<IUnityContainer>(_container);
            UnityContainerInstance.Container = _container;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityContainerInstance.Container.Dispose();
        }
    }
}