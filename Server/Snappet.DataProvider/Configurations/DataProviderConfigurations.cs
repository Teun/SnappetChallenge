using Snappet.DataProvider.Component;
using Snappet.DataProvider.DataProvider;
using Snappet.Model.Common;
using Snappet.Model.DataProvider;
using System.ComponentModel.Composition;
using Unity;

namespace Snappet.DataProvider.Configurations
{
    [Export(typeof(IComponentConfiguration))]
    class DataProviderConfigurations : IComponentConfiguration
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IWorkReportJSONDataProvider, WorkReportJSONDataProvider>("JSON");
            container.RegisterType<IDataProvider, JsonDataProvider>("JSON");

            //NOTE: You can register type for CSV or other type also(With Alias Name).
        }
    }
}
