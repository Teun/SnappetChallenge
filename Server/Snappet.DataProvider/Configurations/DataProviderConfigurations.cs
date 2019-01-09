using Snappet.DataProvider.Component;
using Snappet.DataProvider.DataProvider;
using Snappet.Model;
using Snappet.Model.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.DataProvider.Configurations
{
    [Export(typeof(IComponentConfiguration))]
    class DataProviderConfigurations : IComponentConfiguration
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IStudentJSONDataProvider, StudentJSONDataProvider>("JSON");
            container.RegisterType<IWorkReportJSONDataProvider, WorkReportJSONDataProvider>("JSON");
            container.RegisterType<IDataProvider, JsonDataProvider>("JSON");
        }
    }
}
