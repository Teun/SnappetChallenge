using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using WebAPI.Unity;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApi.UnityWebApiActivator.UnityWebApiActivator), nameof(WebApi.UnityWebApiActivator.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApi.UnityWebApiActivator.UnityWebApiActivator), nameof(WebApi.UnityWebApiActivator.UnityWebApiActivator.Shutdown))]

namespace WebApi.UnityWebApiActivator
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            

            // GlobalConfiguration.Configuration.DependencyResolver = resolver;
            UnityConfigurations unity = new UnityConfigurations();
            IUnityContainer _contaner = unity.UnityResolver();
            var resolver = new UnityDependencyResolver(_contaner);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            //UnityConfig.Container.Dispose();
        }
    }
}