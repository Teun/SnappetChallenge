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
    public class EducatorSubjectOverviewController : ControllerBase
    {
        private readonly IQueryHandler<GetEducatorSubjectOverviewQuery, Task<IEnumerable<EducatorSubjectOverviewResponse>>> _queryHandler;
        private readonly IMapper<EducatorSubjectOverviewResponse, SubjectStudentOverviewDto> _mapper;

        public EducatorSubjectOverviewController(
            IQueryHandler<GetEducatorSubjectOverviewQuery, Task<IEnumerable<EducatorSubjectOverviewResponse>>> queryHandler,
            IMapper<EducatorSubjectOverviewResponse, SubjectStudentOverviewDto> mapper)
        {
            _queryHandler = queryHandler;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectStudentOverviewDto>> Get(string subject, DateTime startDateTimeUtc, DateTime endDateTimeUtc)
        {
            //TODO: Date range validation
            var query = new GetEducatorSubjectOverviewQuery
            {
                Subject = subject,
                StartDateTimeUtc = startDateTimeUtc,
                EndDateTimeUtc = endDateTimeUtc
            };

            var queryResponse = await _queryHandler.Handle(query);
            var response = queryResponse.Select(_mapper.Map).ToList();
            return response;
        }
    }
}
