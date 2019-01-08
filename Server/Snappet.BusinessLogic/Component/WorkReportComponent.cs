using Snappet.Common.BusinessLogic;
using Snappet.Model.BusinessLogic;
using Snappet.Model.DataProvider;
using Snappet.Model.Filters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.BusinessLogic.Component
{
    public class WorkReportComponent : BusinessComponent, IWorkReportComponent
    {
        string fileProvider = null;
        public WorkReportComponent(IUnityContainer container) : base(container)
        {
            fileProvider =  ConfigurationManager.AppSettings["fileprovider"].ToString();
        }

        private IWorkReportJSONDataProvider workReportJSONDataProvider;
        internal IWorkReportJSONDataProvider WorkReportJSONDataProvider
        {
            get { return workReportJSONDataProvider = workReportJSONDataProvider ?? GetRepository<IWorkReportJSONDataProvider>(fileProvider); }
        }

        public IEnumerable<FilterDateSubject> GetFilterDetails()
        {
            return WorkReportJSONDataProvider.GetFilterDetails();
        }

        public IEnumerable<FilterDateSubject> GetFilterDetailsByDate(string dateTime)
        {
            return WorkReportJSONDataProvider.GetFilterDetailsByDate(dateTime);
        }
    }
}
