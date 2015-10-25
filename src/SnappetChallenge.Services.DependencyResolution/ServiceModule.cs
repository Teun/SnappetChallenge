using System;
using Ninject.Activation;
using Ninject.Modules;
using SnappetChallenge.Services.Contracts;

namespace SnappetChallenge.Services.DependencyResolution
{
    public class ServiceModule : NinjectModule
    {
        // this scopeCallback business could probably be moved to a base class
        private readonly Func<IContext, object> scopeCallback;

        public ServiceModule(Func<IContext, object> scopeCallback)
        {
            this.scopeCallback = scopeCallback;
        }

        public override void Load()
        {
            
            Bind<IExerciseService>().To<ExerciseService>();
            Bind<IUserService>().To<UserService>();
            Bind<ISubjectService>().To<SubjectService>();


            foreach (var binding in Bindings)
                binding.ScopeCallback = scopeCallback; ;
        }
    }
}