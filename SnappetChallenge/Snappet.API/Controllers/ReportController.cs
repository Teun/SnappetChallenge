using Microsoft.AspNetCore.Mvc;
using Snappet.API.ViewModels;

namespace Snappet.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpPost("daily-report")]
        public IActionResult DailyReport(DailyReportRequest date)
        {
            _logger.LogInformation("Daily report for: {date}", date);
            return Ok();
        }

    }
}
