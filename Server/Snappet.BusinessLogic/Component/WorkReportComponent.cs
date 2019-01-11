using Snappet.Common.BusinessLogic;
using Snappet.Model.BusinessLogic;
using Snappet.Model.DataProvider;
using Snappet.Model.Domain;
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
        public WorkReportComponent(IUnityContainer container) : base(container)
        {
        }

        string dataType = null;
        public string DataType
        {
            get
            {
                return dataType = dataType ?? ConfigurationManager.AppSettings["dataType"].ToString();
            }
        }
        private IWorkReportJSONDataProvider workReportJSONDataProvider;
        public IWorkReportJSONDataProvider WorkReportJSONDataProvider
        {
            get
            { return workReportJSONDataProvider = workReportJSONDataProvider ?? GetBusinessComponent<IWorkReportJSONDataProvider>(DataType); }
        }

        public IEnumerable<FilterDateSubject> GetFilterDetails()
        {
            return WorkReportJSONDataProvider.GetFilterDetails();
        }

        public IEnumerable<FilterDateSubject> GetFilterDetailsByDate(string dateTime)
        {
            return WorkReportJSONDataProvider.GetFilterDetailsByDate(dateTime);
        }

        public IEnumerable<WorkReport> GetWorkReport(DateTime date, string subject, string domain)
        {
            return WorkReportJSONDataProvider.GetWorkReport(date, subject, domain);
        }
    }
}
