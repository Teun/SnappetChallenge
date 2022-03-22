using Microsoft.AspNetCore.Mvc;
using Snappet.API.ViewModels;

namespace Snappet.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        [HttpPost("daily-report")]
        public IActionResult DailyReport(DailyReportRequest date)
        {

            return Ok();
        }

    }
}
