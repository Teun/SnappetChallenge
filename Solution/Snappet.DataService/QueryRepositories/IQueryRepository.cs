using System;
using System.Collections.Generic;
using Snappet.Data.DataObjects;

namespace Snappet.Data.QueryRepositories
{
    public interface IQueryRepository
    {
        IEnumerable<JsonData> GetDayResults(DateTime utcNow);
    }
}