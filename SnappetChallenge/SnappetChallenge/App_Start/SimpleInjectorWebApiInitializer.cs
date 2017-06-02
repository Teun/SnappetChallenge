[assembly: WebActivator.PostApplicationStartMethod(typeof(SnappetChallenge.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace SnappetChallenge.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using SnappetChallenge.DAL.Repositories;
    using SnappetChallenge.DAL.Services;
    using SnappetChallenge.DAL.Repositories.Contracts;
    using SnappetChallenge.DAL.Services.Contracts;

    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IWorkRepository>(() => WorkRepository.LoadData());
            container.Register<IProgressService, ProgressService>();
            container.Register<IChartService, ChartService>();
        }
    }
}