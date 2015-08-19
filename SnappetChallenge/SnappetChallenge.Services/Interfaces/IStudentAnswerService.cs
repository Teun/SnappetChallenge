namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using DAL.Entities;

    public interface IStudentAnswerService
    {
        List<StudentAnswer> Get(Expression<Func<StudentAnswer, bool>> whereClause, int startIndex, int pageSize );
    }
}
