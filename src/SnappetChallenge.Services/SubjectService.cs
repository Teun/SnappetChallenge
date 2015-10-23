using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Domain.Contracts;

namespace SnappetChallenge.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISnappetChallengeContext context;

        public SubjectService(ISnappetChallengeContext context)
        {
            this.context = context;
        }

        public Dictionary<Subject, float> GetTimeSpentInPercentagesBySubject(DateTime from, DateTime until)
        {
            var allAnswers = context.GetRepository<SubmittedAnswer>().GetAll();

            var filteredAnswers =
                from answer in allAnswers
                where answer.SubmittedOn >= @from && answer.SubmittedOn <= until
                select answer;

            int count = filteredAnswers.Count();

            var resultDictionary =
                (
                    from answer in filteredAnswers
                    group answer by answer.Exercise.LearningObjective.Domain.Subject
                    into grp
                    select new
                    {
                        Subject = grp.Key,
                        Percentage = (grp.Count() / (float)count) * 100
                    }
                ).ToDictionary(result => result.Subject, result => result.Percentage);

            return resultDictionary;
        }
    }
}