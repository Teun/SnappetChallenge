using Snappet.Model.BusinessLogic;
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
        [Route("Get")]
        public IEnumerable<FilterDateSubject> GetAllFilters()
        {
            var filters = WorkReportComponent.GetFilterDetails();
            return filters;
        }

        [HttpGet]
        [Route("Get/{dateTime}")]
        public IEnumerable<FilterDateSubject> GetAllFiltersByDate(string dateTime)
        {
            var filters = WorkReportComponent.GetFilterDetailsByDate(dateTime);
            return filters;
        }
    }
}
