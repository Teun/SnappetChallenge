using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sdk.Api.Dtos;
using Sdk.Api.Utils;
using Service.Teachers.GetTeacherDashboard;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeachersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Get teachers's dashboard.
        /// </summary>
        [HttpGet("dashboard")]
        [ProducesResponseType(typeof(GetTeacherDashboardServiceResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponseDto), (int) HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTeacherDashboard(CancellationToken cancellationToken)
        {
            var dashboardResponse = await _mediator.Send(new GetTeacherDashboardServiceRequest(), cancellationToken);

            return ApiActionResult.Ok(dashboardResponse);
        }
    }
}