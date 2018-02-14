using Autofac;
using Snappet.Business.IManager;
using Snappet.ServiceRegistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.REST.Service.Tests.Dependency
{
    public class BaseTest
    {
        protected IWorkManager _workManager;
        public BaseTest()
        {
            var builder = new ContainerBuilder();
            builder = ServiceTypeRegistry.Register(builder);
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                _workManager = scope.Resolve<IWorkManager>();
            }
        }
    }
}
