using SnappetChallenge.DAL;

namespace SnappetChallenge.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Mvc;

    using DAL.Entities;
    using DAL.Repository;
    using Services.Implementations;
    using Services.Interfaces;

    public class Bootstrapper
    {
        static Bootstrapper()
        {
            RegisterAreas();
            RegisterBundles();
            RegisterFilters();
            RegisterRoutes();
            RegisterUnity();
        }

        public static IUnityContainer RegisterUnity()
        {
            var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // TODO pay attention to object lifetimes
            container.RegisterType<ISnappetChallengeContext, SnappetChallengeContext>(new TransientLifetimeManager());
            container.RegisterType<IAnswerService, AnswerService>(new TransientLifetimeManager());
            container.RegisterType<IExerciseService, ExerciseService>(new TransientLifetimeManager());
            container.RegisterType<IObjectiveService, ObjectiveService>(new TransientLifetimeManager());
            container.RegisterType<IStudentService, StudentService>(new TransientLifetimeManager());

            container.RegisterType<IStudentAnswerService, StudentAnswerService>(new TransientLifetimeManager());
            container.RegisterType<IStudentDeviationsService, StudentDeviationsService>(new TransientLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
        } 

        public static void RegisterBundles()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterAreas()
        {
            AreaRegistration.RegisterAllAreas();
        }

        public static void RegisterFilters()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        public static void RegisterRoutes()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        public void Dispose()
        {
            
        }
    }
}