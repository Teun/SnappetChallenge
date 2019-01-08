using Snappet.Model.DataProvider;
using System;
using System.Configuration;
using System.Web;

namespace Snappet.DataProvider.DataProvider
{
    public interface IDataProviderFactory
    {
        IWorkDataProvider GetDataProvider();
    }

    public class DataProviderFactory : IDataProviderFactory
    {
        public virtual IWorkDataProvider GetDataProvider()
        {
            var fileProvider = ConfigurationManager.AppSettings["fileprovider"];
            IWorkDataProvider workDataProvider = null;
            switch (fileProvider)
            {
                case "json":
                    var filePath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["filePath"]);
                    workDataProvider = new JsonDataProvider(filePath);
                    break;
                default:
                    throw new Exception("Data provder not available");
            }

            return workDataProvider;
        }
    }
}

