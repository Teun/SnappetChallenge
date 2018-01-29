using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Core.Interfaces;
using SnappetChallenge.Core.Services;
using SnappetChallenge.Infrastructure;

namespace SnappetChallenge.Application
{
    public static class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<DbContext, AssessmentContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Transient);
            container.Register<ICommands<Assessment>, Commands<Assessment>>(Lifestyle.Transient);
            container.Register<IQueries<Assessment>, Queries<Assessment>>(Lifestyle.Transient);
            container.Register<IAssessmentService, AssessmentService>(Lifestyle.Transient);          
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}