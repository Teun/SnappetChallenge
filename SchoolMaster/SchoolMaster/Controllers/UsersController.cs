using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMaster.Services;

namespace SchoolMaster.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISubmissionReportService _submissionReportService;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ISubmissionReportService submissionReportService)
        {
            _userService = userService;
            _submissionReportService = submissionReportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return Ok(await _userService.GetAllUsersAsync(cancellationToken));
        }


        [HttpGet("{userId}/submissions")]
        public async Task<IActionResult> GetUserSubmissionsAsync(int userId
            , [FromQuery] DateTime startDate
            , [FromQuery] DateTime endDate
            , CancellationToken cancellationToken = default)
        {
            return Ok(await _submissionReportService.GetSubmissionCountByUserIdAsync(startDate
                , endDate, userId, cancellationToken));
        }
    }
}