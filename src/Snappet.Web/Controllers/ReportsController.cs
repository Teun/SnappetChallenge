using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet.Reporting.Model;
using Snappet.Reporting.Services;

namespace Snappet.Web.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly IWorkStatisticsService service;
        public ReportsController(IWorkStatisticsService service)
        {
            this.service = service;            
        }

        [HttpGet("work")]
        public IEnumerable<WorkStatisticsByTopic> GetWorkStatisticsByTopic(DateTime from, DateTime to)
        {
            // TODO: validate params

            var result = service.GetWorkStatisticsByTopic(from, to);

            return result;
        }

    }
}
