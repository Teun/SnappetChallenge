using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Dictionary<string, float> GetTimeSpentInPercentagesBySubject(DateTime from, DateTime until)
        {
            // EF7 prerelease is buggy as hell, need to actually load in nearly the entire db here, so much for IQueryable

            context.GetRepository<LearningObjective>().GetAll().ToList();
            context.GetRepository<Domain.Entities.Domain>().GetAll().ToList();
            context.GetRepository<Subject>().GetAll().ToList();
            var exercises = context.GetRepository<Exercise>().GetAll().ToList();

            int total = exercises.Count();

            var resultDictionary =
                (
                    from exercise in exercises
                    group exercise by exercise.LearningObjective.Domain.Subject
                    into grp
                    select new
                    {
                        Subject = grp.Key,
                        Percentage = (grp.Count() / (float)total) * 100
                    }
                ).ToDictionary(result => result.Subject.Description, result => result.Percentage);

            return resultDictionary;
        }
    }
}
