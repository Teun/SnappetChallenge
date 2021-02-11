using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMaster.Services;

namespace SchoolMaster.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionReportService _submissionReportService;

        public SubmissionsController(ISubmissionReportService submissionReportService)
        {
            _submissionReportService = submissionReportService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserSubmissionsAsync([FromQuery] DateTime startDate
            , [FromQuery] DateTime endDate
            , CancellationToken cancellationToken = default)
        {
            return Ok(await _submissionReportService.GetSubmissionCountByUserIdAsync(startDate
                , endDate, default, cancellationToken));
        }
    }
}