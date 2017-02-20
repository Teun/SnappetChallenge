using System.Data.Common;
using NServiceBus;
using NServiceBus.Pipeline;
using Snappet.Test.Infrastructure.NServiceBus;
using Snappet.Test.Infrastructure.NServiceBus.Behaviours;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Data;

namespace Snappet.Test.TopStudents.Host.Behaviours
{
    public class TopStudentsUnitOfWorkBehaviour : UnitOfWorkBehaviourBase<ITopStudentsUnitOfWork>
    {
        internal class RegisterStep : INeedInitialization
        {
            public void Customize(EndpointConfiguration configuration)
            {
                configuration.Pipeline.Register<UnitOfWorkStepRegistry<TopStudentsUnitOfWorkBehaviour>>();
            }
        }

        protected override ITopStudentsUnitOfWork CreateUnitOfWork(IInvokeHandlerContext context)
        {
            DbConnection dbConnection = context.GetDbConnection();
            DbTransaction dbTransaction = context.GetDbCTransaction();
            return new TopStudentsDbContext(dbConnection, dbTransaction);
        }
    }
}
