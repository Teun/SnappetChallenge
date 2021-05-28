using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Snappet.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _mediator.Send(new GetDailyStatsQuery());
            return Ok(stats);
        }
    }
}
