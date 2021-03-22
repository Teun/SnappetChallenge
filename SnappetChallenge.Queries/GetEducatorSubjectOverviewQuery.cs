using SnappetChallenge.Queries.Interfaces;
using SnappetChallenge.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Queries
{
    public class GetEducatorSubjectOverviewQuery : IQuery<Task<IEnumerable<EducatorSubjectOverviewResponse>>>
    {
        public string Subject { get; init; }
        public DateTime StartDateTimeUtc { get; init; }
        public DateTime EndDateTimeUtc { get; init; }
    }
}
