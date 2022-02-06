using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Application.Business.Commands;

namespace SnappetChallenge.Api.Controllers
{
    public class SubmittedAnswersController : ApiControllerBase
    {
        [HttpGet]
        [Route("progress-report")]
        public async Task<IActionResult> Get()
        {
            var showsResult = await Mediator.Send(new GetProgressReportCommand());
            return Ok(showsResult);
        }
    }
}