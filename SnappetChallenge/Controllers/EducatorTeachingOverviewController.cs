using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Mappers.Interfaces;
using SnappetChallenge.Models;
using SnappetChallenge.Queries;
using SnappetChallenge.Queries.Interfaces;
using SnappetChallenge.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducatorTeachingOverviewController : ControllerBase
    {
        private readonly IQueryHandler<GetDashboardQuery, Task<IEnumerable<DashboardResponse>>> _queryHandler;
        private readonly IMapper<DashboardResponse, SubjectOverviewDto> _mapper;

        public EducatorTeachingOverviewController(
            IQueryHandler<GetDashboardQuery, Task<IEnumerable<DashboardResponse>>> queryHandler,
            IMapper<DashboardResponse, SubjectOverviewDto> mapper)
        {
            _queryHandler = queryHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectOverviewDto>> Get(DateTime startDateTimeUtc, DateTime endDateTimeUtc)
        {
            // TODO: Validation
            var query = new GetDashboardQuery 
            { 
                StartDateTimeUtc = startDateTimeUtc,
                EndDateTimeUtc = endDateTimeUtc
            };

            var queryResponse = await _queryHandler.Handle(query);
            var response = queryResponse.Select(_mapper.Map).ToList();
            return response;
        }
    }
}
