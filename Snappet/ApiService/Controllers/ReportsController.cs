using Microsoft.AspNetCore.Mvc;
using System;
using ApiService.Properties;
using ApiService.Services;
using BlCore.ReportServices;

namespace ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Objectives")]
        public IActionResult GetObjectivesReport(string begin, string end)
        {
            if (!ValidateDateTime(begin, end, out DateTime beginDt, out DateTime endDt))
            {
                return new BadRequestObjectResult(Resources.BadDateTimeFormat);
            }
            return new JsonResult(_reportService.GetObjectivesReport(beginDt, endDt));
        }

        [HttpGet("Objectives/One")]
        public IActionResult GetOneObjectiveReport(string obj, string begin, string end)
        {
            if (!ValidateDateTime(begin, end, out DateTime beginDt, out DateTime endDt))
            {
                return new BadRequestObjectResult(Resources.BadDateTimeFormat);
            }
            return new JsonResult(_reportService.GetOneObjectiveReport(obj, beginDt, endDt));
        }

        [HttpGet("Users")]
        public IActionResult GetUsersReport(string begin, string end)
        {
            if (!ValidateDateTime(begin, end, out DateTime beginDt, out DateTime endDt))
            {
                return new BadRequestObjectResult(Resources.BadDateTimeFormat);
            }
            return new JsonResult(_reportService.GetUsersReport(beginDt, endDt));
        }


        [HttpGet("Users/One")]
        public IActionResult GetOneUserReport(int user, string begin, string end)
        {
            if (!ValidateDateTime(begin, end, out DateTime beginDt, out DateTime endDt))
            {
                return new BadRequestObjectResult(Resources.BadDateTimeFormat);
            }
            return new JsonResult(_reportService.GetOneUserReport(user, beginDt, endDt));
        }

       
        private bool ValidateDateTime(string begin, string end, out DateTime beginDt, out DateTime endDt)
        {
            endDt = DateTime.MinValue;
            return DateTimeFormats.TryParse(begin, out beginDt) && DateTimeFormats.TryParse(end, out endDt);
        }


    }
}
