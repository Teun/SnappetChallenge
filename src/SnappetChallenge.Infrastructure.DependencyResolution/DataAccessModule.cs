using Ninject.Modules;
using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Infrastructure.DataAccess;

namespace SnappetChallenge.Infrastructure.DependencyResolution
{
    public class DataAccessModule : NinjectModule
    {
        private readonly string connectionString;

        public DataAccessModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<ISnappetChallengeContext>().To<SnappetChallengeContext>().WithConstructorArgument("connectionString", connectionString);
        }
    }
}