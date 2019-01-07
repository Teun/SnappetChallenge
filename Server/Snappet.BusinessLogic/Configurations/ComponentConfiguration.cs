using Snappet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.BusinessLogic
{
    [Export(typeof(IComponentConfiguration))]
    class ComponentConfiguration : IComponentConfiguration
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType<IStudentFacade, StudentFacade>();
        }
    }
}
