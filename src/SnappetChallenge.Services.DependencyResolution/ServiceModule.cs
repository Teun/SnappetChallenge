using Ninject.Modules;
using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
