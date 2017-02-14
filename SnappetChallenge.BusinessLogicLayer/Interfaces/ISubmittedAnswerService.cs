using System;
using System.Collections.Generic;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.BusinessLogicLayer.Services;

namespace SnappetChallenge.BusinessLogicLayer.Interfaces
{
    public interface ISubmittedAnswerService
    {
        List<SubmittedAnswer> GetSubmittedAnswers();
        TopStudentStatistic GetTopStudentStatistic(int count, string subject);

        List<SubmittedAnswer> GetByUserId(long userId);

        List<SubmittedAnswer> GetForPeriod(DateTime from, DateTime to,
            bool includeFrom = true, bool includeTo = true);
        List<SubmittedAnswer> GetForPeriodInclude(DateTime from, DateTime to);
        List<SubmittedAnswer> GetForPeriodExclude(DateTime from, DateTime to);
        List<SubmittedAnswer> GetWrongAnswers(long userId, string subject, string domain, string learningObjective);
    }
}