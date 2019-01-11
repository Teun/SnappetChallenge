using Snappet.BusinessLogic.Component;
using Snappet.Model.Common;
using Snappet.Model.BusinessLogic;
using System.ComponentModel.Composition;
using Unity;

namespace Snappet.BusinessLogic
{
    [Export(typeof(IComponentConfiguration))]
    class ComponentConfiguration : IComponentConfiguration
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IWorkReportComponent, WorkReportComponent>();
        }
    }
}
