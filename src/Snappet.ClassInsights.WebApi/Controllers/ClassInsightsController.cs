using Microsoft.Extensions.Logging;
using Snappet.ClassInsights.Business.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Snappet.ClassInsights.WebApi.Controllers
{
    [Route("api/insights")]
    [ApiController]
    public class ClassInsightsController : ControllerBase
    {
        private readonly IInsightsService _insightsService;
        private readonly ILogger<ClassInsightsController> _logger;

        public ClassInsightsController(IInsightsService insightsService, ILogger<ClassInsightsController> logger)
        {
            _insightsService = insightsService;
            _logger = logger;
        }

        [HttpGet("pubilsDaily/{day}")]
        public async Task<IActionResult> GetPubilsDailyInsightAsync(DateTime day)
        {
            try
            {
                var result = await _insightsService.GetPubilsDailyInsightsAsync(day);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting pubils daily insights");
                return StatusCode(500);
            }

        }

        [HttpGet("subjectsDaily/{day}")]
        public async Task<IActionResult> GetDailySubmittedAnswersPerSubjectInsightAsync(DateTime day)
        {
            try
            {
                var result = await _insightsService.GetSubmittedAnswersPerSubjectInsights(day);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Subjects daily insights");
                return StatusCode(500);
            }
        }
    }
}
