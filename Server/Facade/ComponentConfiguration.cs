using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ChildMEF
{
    [Export(typeof(IUnityConfiguration))]
    class ComponentConfiguration : IUnityConfiguration
    {
        public void RegisterType(IUnityContainer container)
        {
            container.RegisterType(typeof(IStudentFacade), typeof(StudentFacade));
        }
    }
}
