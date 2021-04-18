using BlCore.DataProviders;
using BlCore.IoC;
using BlCore.ReportServices;

namespace BlCore.BlServicesProviders
{
    public class BlServicesProvider : IBlServicesProvider
    {
        private readonly ISnappetDependencyResolver _resolver;

        public BlServicesProvider()
        {
            _resolver = new SnappetDependencyResolver();
        }

        public IReportService GetReportService()
        {
            return _resolver.Resolve<IReportService>();
        }

        public void SetDataProvider(IDataProvider dataProvider)
        {
            _resolver.RegisterInstance(dataProvider);
        }
    }
}