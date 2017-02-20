using System.Data;
using System.Data.Common;
using NHibernate;
using NServiceBus;
using Snappet.Test.Kernel;

namespace Snappet.Test.Infrastructure.NServiceBus
{
    public static class ContextExtensions
    {
        public static T GetUnitOfWork<T>(this IMessageHandlerContext context)
           where T : IUnitOfWork
        {
            return context.Extensions.Get<T>();
        }

        public static DbConnection GetDbConnection(this IMessageHandlerContext context)
        {
            ISession session = context.SynchronizedStorageSession.Session();
            var dbConnection = (DbConnection)session.Connection;
            return dbConnection;
        }

        public static DbTransaction GetDbCTransaction(this IMessageHandlerContext context)
        {
            ISession session = context.SynchronizedStorageSession.Session();
            DbTransaction dbTransaction;
            using (IDbCommand command = session.Connection.CreateCommand())
            {
                session.Transaction.Enlist(command);
                dbTransaction = (DbTransaction)command.Transaction;
            }
            return dbTransaction;
        }
    }
}