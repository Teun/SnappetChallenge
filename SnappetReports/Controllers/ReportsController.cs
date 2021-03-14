using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnappetReports.Data.Services;

namespace SnappetReports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        private IReportsService _service;
        public ReportsController(IReportsService service)
        {
            _service = service;
        }


        [HttpGet("[action]")]
        public IActionResult GetReportRecords()
        {
            var reportRecords = _service.GetReportRecords();
            return Ok(reportRecords);
        }

    }
}
