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
            var reportRecords =  _service.GetReportRecords();
            return Ok(reportRecords);
        }

        [HttpGet("GetReportJSON")]
        public IActionResult GetReportJSON()
        {
            var reportRecords = _service.GetReportJSON();
            return Ok(reportRecords);
        }

        [HttpGet("GetsubjectAnswerCount")]
        public IActionResult GetSubjectAnswerCount()
        {
            var reportRecords = _service.GetSubjectAnswerCount();
            return Ok(reportRecords);
        }

        [HttpGet("GetUserReports")]
        public IActionResult GetUserReports()
        {
            var userRecords = _service.GetUserReports();
            return Ok(userRecords);
        }

        [HttpGet("GetSubjectDailyReports")]
        public IActionResult GetSubjectDailyReports()
        {
            var subjectDailyReports = _service.GetSubjectDailyReports();
            return Ok(subjectDailyReports);
        }

    }
}
