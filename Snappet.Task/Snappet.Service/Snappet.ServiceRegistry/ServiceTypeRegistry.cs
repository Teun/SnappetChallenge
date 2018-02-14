using Autofac;
using Snappet.Business;
using Snappet.Business.IManager;
using Snappet.EFRepository.UnitOfWork;
using Snappet.Repository;
using Snappet.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.ServiceRegistry
{
    public static class ServiceTypeRegistry
    {
        /// <summary>
        /// Register 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ContainerBuilder Register(ContainerBuilder builder)
        {
            // UnitOfWork
            builder.Register<UnitOfWork>(b => new UnitOfWork()).As<IUnitOfWork>().InstancePerLifetimeScope();

            RegisterTyps(builder);
            return builder;
        }
        
        /// <summary>
        /// Register all types " Repositories - Managers - Factories "
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterTyps(ContainerBuilder builder)
        {
            #region Repository
            builder.RegisterType<WorkRepository>().As<IWorkRepository>().InstancePerLifetimeScope();
            #endregion

            #region Managers
            builder.RegisterType<WorkManager>().As<IWorkManager>().InstancePerLifetimeScope();
            #endregion
            
        }
    }
}
