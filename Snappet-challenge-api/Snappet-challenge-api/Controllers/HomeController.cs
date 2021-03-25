using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Snappet_challenge_api.Services;

namespace Snappet_challenge_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public readonly IConfiguration _config;
        public readonly ISummaryDataService _summaryDataService;

        public HomeController(IConfiguration config, ISummaryDataService summaryDataService)
        {
            _config = config;
            _summaryDataService = summaryDataService;
        }

        [HttpGet("get-dashboard-data")]
        public IActionResult GetDashboardData(string summaryDate)
        {
            var usersSummaryData = _summaryDataService.GetSummaryData(summaryDate);
            if(usersSummaryData is null)
            {
                return BadRequest("Error retrieving data");
            }

            return Ok(usersSummaryData);
        }

        [HttpGet("get-subjects")]
        public IActionResult GetSubjects(string summaryDate)
        {
            var subjects = _summaryDataService.GetSubjects(summaryDate);
            if(subjects is null)
            {
                return BadRequest("Error retrieving data");
            }

            return Ok(subjects);
        }
        
    }
}
