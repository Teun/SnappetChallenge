using Snappet.Domain.Interface.Repository;
using Snappet.Domain.Models;
using System.Linq;

namespace Snappet.Infrastructure.Persistence
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DbContext _dbContext;

        public ExerciseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IEnumerable<ExerciseReportModel> GetDailyReport(DateOnly date)
        //{
        //    var exe = _dbContext.ExerciseReports.Select(x => x.ExerciseId).Distinct();
        //    return _dbContext.ExerciseReports.Where(i => DateOnly.FromDateTime(i.SubmitDateTime) == date).ToList();
        //}

        public IEnumerable<StudentExerciseActivityModel> GetStudentActivity(DateOnly date, int skip = 0, int take = 10)
        {
            var data = _dbContext.ExerciseReports
                .Where(i => DateOnly.FromDateTime(i.SubmitDateTime) == date)
                .GroupBy(x => x.UserId, x => x);

            return data.Select(x => new StudentExerciseActivityModel
            {
                UserId = x.Key,
                OverallProgress = 0, // TODO

            }).Skip(skip).Take(take).ToList();

        }

        public IEnumerable<ExerciseModel> GetStudentExercises(DateOnly date, int studentId, int skip = 0, int take = 10)
        {
            var data = _dbContext.ExerciseReports
                .Where(i => DateOnly.FromDateTime(i.SubmitDateTime) == date)
                .Where(i => i.UserId == studentId)
                .Select(i => new ExerciseModel
                {
                    ExerciseId = i.ExerciseId,
                    Correct = i.Correct == 0 ? false : true,
                    Difficulty = i.Difficulty,
                    Domain = i.Domain,
                    LearningObjective = i.LearningObjective,
                    Progress = i.Progress,
                    Subject = i.Subject,
                    SubmitDateTime = i.SubmitDateTime,
                    SubmittedAnswerId = i.SubmittedAnswerId,
                })
                .Skip(skip).Take(take).ToList();

            return data;
        }
    }
}
