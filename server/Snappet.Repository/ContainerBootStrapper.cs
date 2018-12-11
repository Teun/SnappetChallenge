using Snappet.Repository.DataProvider;
using SnappetRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace Snappet.Repository
{
    public class ContainerBootStrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDataProviderFactory, DataProviderFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IDataProvider, Snappet.Repository.DataProvider.DataProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassRepository, ClassRepository>(new HierarchicalLifetimeManager());
        }
    }
}
