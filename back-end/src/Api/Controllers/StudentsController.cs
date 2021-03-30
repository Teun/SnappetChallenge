using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sdk.Api.Dtos;
using Sdk.Api.Utils;
using Service.Students.GetStudentOverviewByUserId;
using Service.Students.GetStudentsOverview;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Get students's overview.
        /// </summary>
        [HttpGet("overview")]
        [ProducesResponseType(typeof(GetStudentsOverviewServiceResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponseDto), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetStudentsOverview(CancellationToken cancellationToken)
        {
            var overviewResponse = await _mediator.Send(new GetStudentsOverviewServiceRequest(), cancellationToken);

            return ApiActionResult.Ok(overviewResponse);
        }

        /// <summary>
        ///     Get students's overview by userId.
        /// </summary>
        [HttpGet("{userId}/overview")]
        [ProducesResponseType(typeof(ApiResponseDto<GetStudentOverviewByUserIdServiceResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponseDto), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetStudentsOverviewByUserId([FromRoute] int userId, CancellationToken cancellationToken)
        {
            var overviewResponse = await _mediator.Send(new GetStudentOverviewByUserIdServiceRequest
            {
                UserId = userId
            }, cancellationToken);

            return ApiActionResult.Ok(overviewResponse);
        }
    }
}
