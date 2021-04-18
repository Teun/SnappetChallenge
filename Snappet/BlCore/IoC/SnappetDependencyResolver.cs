using BlCore.ReportServices;
using Unity;

namespace BlCore.IoC
{
    internal class SnappetDependencyResolver : ISnappetDependencyResolver
    {
        private readonly UnityContainer _container;

        public SnappetDependencyResolver()
        {
            _container = new UnityContainer();
            InitContainer(_container);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _container.RegisterInstance(instance);
        }

        private void InitContainer(UnityContainer container)
        {
            container.RegisterType<IReportService, ReportService>();
        }
    }
}