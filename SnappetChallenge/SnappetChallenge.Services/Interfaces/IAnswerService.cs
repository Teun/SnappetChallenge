
namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DAL.Entities;

    public interface IAnswerService
    {
        List<Answer> Get(Expression<Func<Answer, bool>> whereClause);
    }
}
