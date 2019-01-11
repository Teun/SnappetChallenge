using Snappet.Model.BusinessLogic;
using Snappet.Model.Domain;
using Snappet.Model.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Work")]
    public class WorkReportController : ApiController
    {
        private IWorkReportComponent WorkReportComponent;
        public WorkReportController(IWorkReportComponent workReportComponent)
        {
            this.WorkReportComponent = workReportComponent;
        }

        [HttpGet]
        [Route("GetAllFilters")]
        public IEnumerable<FilterDateSubject> GetAllFilters()
        {
            var filters = WorkReportComponent.GetFilterDetails();
            return filters;
        }

        [HttpGet]
        [Route("GetAllFiltersByDate")]
        public IEnumerable<FilterDateSubject> GetAllFiltersByDate(string dateTime)
        {
            var filters = WorkReportComponent.GetFilterDetailsByDate(dateTime);
            return filters;
        }

        [HttpGet]
        
        [Route("GetReportByDateSubjectDomain")]
        public IEnumerable<WorkReport> GetReportByDateSubjectDomain(string dateTime, string domain, string subject)
        {
            var workReport = WorkReportComponent.GetWorkReport(DateTime.Parse(dateTime), subject, domain);
            return workReport;
        }
    }
}
