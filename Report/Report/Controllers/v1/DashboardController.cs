using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Report.Data;
using Report.Query;

namespace Report.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DashboardController : ControllerBase
    { 
        private readonly ILogger<DashboardController> _logger;
        private readonly IApiQuery<TodayDashboard> _todayDashboardApiQuery;

        public DashboardController(ILogger<DashboardController> logger, IApiQuery<TodayDashboard> todayDashboardApiQuery)
        {
            _logger = logger;
            _todayDashboardApiQuery = todayDashboardApiQuery;
        }

        [HttpGet]
        public async Task<TodayDashboard> Get()
        {
            string apiMethod = $"api/v1/dashboard";

            _logger.LogInformation($"{apiMethod} started ...");

            var result = await _todayDashboardApiQuery.Execute();

            _logger.LogInformation($"{apiMethod} finished ...");

            return result.Value;
        }
    }
}
