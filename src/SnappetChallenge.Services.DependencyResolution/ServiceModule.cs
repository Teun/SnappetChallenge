using Ninject.Modules;
using SnappetChallenge.Services.Contracts;

namespace SnappetChallenge.Services.DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IExerciseService>().To<ExerciseService>();
            Bind<IUserService>().To<UserService>();
            Bind<ISubjectService>().To<SubjectService>();
        }
    }
}