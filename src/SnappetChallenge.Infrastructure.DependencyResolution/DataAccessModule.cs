using System;
using Ninject.Activation;
using Ninject.Modules;
using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Infrastructure.DataAccess;

namespace SnappetChallenge.Infrastructure.DependencyResolution
{
    public class DataAccessModule : NinjectModule
    {
        private readonly Func<IContext, object> scopeCallback;

        public DataAccessModule(Func<IContext, object> scopeCallback)
        {
            this.scopeCallback = scopeCallback;

        }

        public override void Load()
        {
            Bind<ISnappetChallengeContext>().To<SnappetChallengeContext>();

            foreach (var binding in Bindings)
                binding.ScopeCallback = scopeCallback;;
        }
    }
}