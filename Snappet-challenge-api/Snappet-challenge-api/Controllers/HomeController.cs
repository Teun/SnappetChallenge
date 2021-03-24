using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Snappet_challenge_api.Models;
using Snappet_challenge_api.Services;

namespace Snappet_challenge_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetDashboardData()
        {
            var usersSummaryData = _summaryDataService.GetSummaryData();
            return Ok(usersSummaryData);
        }
        
    }
}
