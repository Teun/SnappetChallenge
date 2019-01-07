using Snappet.Common.BusinessLogic;
using Snappet.Model;
using Snappet.Model.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.BusinessLogic
{
    public class StudentFacade : BusinessComponent, IStudentFacade
    {
        public StudentFacade(IUnityContainer container) : base(container)
        {
        }
        private IStudentJSONDataProvider studentJSONDataProvider;
        internal IStudentJSONDataProvider StudentJSONDataProvider
        {
            get { return studentJSONDataProvider = studentJSONDataProvider ?? GetRepository<IStudentJSONDataProvider>("JSON"); }
        }
        public void GetStudent(string data)
        {
            StudentJSONDataProvider.getStudentData();
            //Console.WriteLine(data);
        }
    }

    
}
