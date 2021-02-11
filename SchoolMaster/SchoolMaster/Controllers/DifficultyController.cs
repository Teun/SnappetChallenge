using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMaster.Services;

namespace SchoolMaster.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IWorkDifficultyReportService _workDifficultyReportService;

        public DifficultyController(IWorkDifficultyReportService workDifficultyReportService)
        {
            _workDifficultyReportService = workDifficultyReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDifficultyReport([FromQuery] DateTime startDate
            , [FromQuery] DateTime endDate, CancellationToken cancellationToken = default)
        {
            return Ok(await _workDifficultyReportService.GetAverageDifficultyAsync(startDate, endDate,
                cancellationToken));
        }
    }
}