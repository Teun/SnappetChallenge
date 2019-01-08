using Snappet.Common.BusinessLogic;
using Snappet.Model.BusinessLogic;
using Snappet.Model.DataProvider;
using Snappet.Model.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.BusinessLogic.Component
{
    public class WorkReportComponent : BusinessComponent, IWorkReportComponent
    {
        public WorkReportComponent(IUnityContainer container) : base(container)
        {
        }

        private IWorkReportJSONDataProvider workReportJSONDataProvider;
        internal IWorkReportJSONDataProvider WorkReportJSONDataProvider
        {
            get { return workReportJSONDataProvider = workReportJSONDataProvider ?? GetRepository<IWorkReportJSONDataProvider>("JSON"); }
        }

        public IEnumerable<FilterDateSubject> GetFilterDetails()
        {
            return WorkReportJSONDataProvider.GetFilterDetails();
        }
    }
}
