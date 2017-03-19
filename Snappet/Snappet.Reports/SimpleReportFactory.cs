using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace Snappet.Reports
{
    public interface IReportFactory
    {
        IReport Create(string reportName);
    }

    public class SimpleReportFactory : Autofac.Module, IReportFactory
    {
        private readonly ILifetimeScope _scope;

        public SimpleReportFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IReport Create(string reportName)
        {
            if (!_scope.IsRegisteredWithName<IReport>(reportName))
            {
                return default(IReport);
            }
            return _scope.ResolveNamed<IReport>(reportName);
        }

        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IReport)));
            foreach (Type type in types)
            {
                if (type.IsAbstract)
                {
                    continue;
                }
                builder.RegisterType(type).Named<IReport>(type.Name);
            }
        }
    }
}