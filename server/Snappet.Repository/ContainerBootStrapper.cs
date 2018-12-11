using Snappet.Repository.Provider;
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
            container.RegisterType<IReportProviderFactory, ReportProviderFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IReportProvider, Snappet.Repository.Provider.ReportProvider>(new HierarchicalLifetimeManager());
            container.RegisterType<IReportRepository, ReportRepository>(new HierarchicalLifetimeManager());
        }
    }
}
