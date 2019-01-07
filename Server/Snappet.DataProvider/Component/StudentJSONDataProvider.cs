using Snappet.Common.BusinessLogic;
using Snappet.Model.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.DataProvider.Component
{
    public class StudentJSONDataProvider : BusinessComponent, IStudentJSONDataProvider
    {
        public StudentJSONDataProvider(IUnityContainer container) : base(container)
        {
        }
        public void getStudentData()
        {

        }
    }
}
