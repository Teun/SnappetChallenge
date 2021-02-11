using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMaster.Services;

namespace SchoolMaster.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IWorkProgressReportService _workProgressReportService;

        public ProgressController(IWorkProgressReportService workProgressReportService)
        {
            _workProgressReportService = workProgressReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProgressReport([FromQuery] DateTime startDate
            , [FromQuery] DateTime endDate, CancellationToken cancellationToken = default)
        {
            return Ok(await _workProgressReportService.GetProgressReportAsync(startDate, endDate, cancellationToken));
        }
    }
}