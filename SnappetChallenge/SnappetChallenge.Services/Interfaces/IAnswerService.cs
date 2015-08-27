using SnappetChallenge.Services.Enums;

namespace SnappetChallenge.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using DAL.Entities;

    public interface IAnswerService
    {
        IEnumerable<Answer> Get(Expression<Func<Answer, bool>> whereClause);

        List<AnswerResult> GetAnswersByStudentAndExerciseInRange(long studentId, long[] exerciseId, DateTime start, DateTime end);
    }
}
