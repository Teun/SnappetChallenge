using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;
using Snappet.Test.Kernel;

namespace Snappet.Test.Infrastructure.NServiceBus.Behaviours
{
    public abstract class UnitOfWorkBehaviourBase<T> : Behavior<IInvokeHandlerContext>
        where T : IUnitOfWork
    {
        public override Task Invoke(IInvokeHandlerContext context, Func<Task> next)
        {
            T unitOfWork = CreateUnitOfWork(context);
            context.Extensions.Set(unitOfWork);

            return next();
        }

        protected abstract T CreateUnitOfWork(IInvokeHandlerContext context);
    }

    public class UnitOfWorkStepRegistry<TConcreteBehaviour> : RegisterStep
    {
        public UnitOfWorkStepRegistry()
            : base(
                typeof(TConcreteBehaviour).Name, typeof(TConcreteBehaviour),
                $"{nameof(TConcreteBehaviour)} - Unit of Work behavior")
        {
        }
    }

}