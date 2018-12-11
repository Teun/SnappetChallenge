using System.Configuration;
using System.Web;

namespace Snappet.Repository.DataProvider
{
    public interface IDataProviderFactory
    {
        IDataProvider GetDataProvider();
    }

    public class DataProviderFactory: IDataProviderFactory
    {
        public IDataProvider GetDataProvider()
        {
            IDataProvider dataProvider = null;
            var filePath = ConfigurationManager.AppSettings["filePath"];
            dataProvider = new DataProvider(filePath);
            return dataProvider;
        }
    }
}
