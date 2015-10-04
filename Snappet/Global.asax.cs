using Ninject;
using Ninject.Web.Common;
using Snappet.DataAccess;
using Snappet.Domain;
using Snappet.Domain.Mappers;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Snappet
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IExerciseResultRepository>().To<ExerciseResultRepository>();
            kernel.Bind<ISubjectRepository>().To<SubjectRepository>();
            kernel.Bind<ILearningObjectiveRepository>().To<LearningObjectiveRepository>();
            kernel.Bind<IDomainRepository>().To<DomainRepository>();
            kernel.Bind<IRelatedDataMapper>().To<RelatedDataMapper>();
            kernel.Bind<IUserMapper>().To<UserMapper>();
            kernel.Bind<IExerciseResultMapper>().To<ExerciseResultMapper>();
            kernel.Bind<IExerciseResultService>().To<ExerciseResultService>();

            return kernel;
        }
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
