
namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DAL.Entities;

    public interface IObjectiveService
    {
        List<Objective> Get(Expression<Func<Objective, bool>> whereClause);

        IEnumerable<Objective> GetObjectivesInRange(DateTime start, DateTime end);
    }
}
