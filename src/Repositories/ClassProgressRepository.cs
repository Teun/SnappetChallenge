using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Core;
using SnappetChallenge.Models;
using SnappetChallenge.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Repositories
{
    public class ClassProgressRepository : IClassProgressRepository
    {
        private readonly SnappetDbContext _dbContext;
        public ClassProgressRepository(SnappetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<LearningObjective>> GetDailyLearningObjectiveProgressAsync(DateTime dateTime)
        {
            return await _dbContext.WorkDataSet
                         .Where(x => x.SubmitDateTime <= dateTime && x.SubmitDateTime.Date == dateTime.Date)
                         .GroupBy(x => new { x.LearningObjective, x.Domain })
                         .Select(x => new LearningObjective
                         {
                             Title = x.Key.LearningObjective,
                             Domain = x.Key.Domain,

                             TotalProgress = x.Sum(y => y.Progress),
                             AverageDifficulty = Math.Round(x.Average(y => y.Difficulty.SafeParseDouble())),
                             TotalStudents = x.GroupBy(y => y.UserId).Count(),
                             TotalSubmittedAnswers = x.Count()
                         })
                         .OrderByDescending(x => x.TotalProgress)
                         .ToListAsync();
        }

        public async Task<IList<Student>> GetDailyStudentsProgressAsync(DateTime dateTime, string learningObjective)
        {
            return await _dbContext.WorkDataSet
                        .Where(x => x.SubmitDateTime <= dateTime && x.SubmitDateTime.Date == dateTime.Date
                                                                 && x.LearningObjective == learningObjective)
                        .GroupBy(x => new { x.UserId, x.Subject })
                         .Select(x => new Student
                         {
                             Id = x.Key.UserId,
                             Subject = x.Key.Subject,

                             CorrectAttempts = x.Count(y => y.Correct),
                             InCorrectAttempts = x.Count(y => !y.Correct),
                             UniqueExercises = x.GroupBy(y => y.ExerciseId).Count(),
                             SubmittedAnswers = x.Count(),
                             CurrentProgress = x.Sum(y => y.Progress),
                             AverageDifficulty = Math.Round(x.Average(y => y.Difficulty.SafeParseDouble())),
                         })
                         .OrderBy(x => x.Id)
                         .ToListAsync();
        }
    }
}
