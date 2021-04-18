using BlCore.DataProviders;
using BlCore.ReportServices;

namespace BlCore.BlServicesProviders
{
    public interface IBlServicesProvider
    {
        IReportService GetReportService();

        void SetDataProvider(IDataProvider dataProvider);
    }
}
