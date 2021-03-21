using SnappetChallenge.Queries.Interfaces;
using SnappetChallenge.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Queries
{
    public class GetEducatorTeachingOverviewQuery : IQuery<Task<IEnumerable<EducatorTeachingOverviewResponse>>>
    {
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }
    }
}
