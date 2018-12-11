using System.Configuration;
using System.Web;

namespace Snappet.Repository.Provider
{
    public interface IReportProviderFactory
    {
        IReportProvider GetReportProvider();
    }

    public class ReportProviderFactory: IReportProviderFactory
    {
        public IReportProvider GetReportProvider()
        {
            IReportProvider reportProvider = null;
            var filePath = ConfigurationManager.AppSettings["filePath"];
            reportProvider = new ReportProvider(filePath);
            return reportProvider;
        }
    }
}
