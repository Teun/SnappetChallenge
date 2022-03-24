using Snappet.Domain;
using Snappet.Domain.Interface;
using Snappet.Domain.Interface.Repository;
using Snappet.Domain.Interface.Service;
using Snappet.Domain.Models;

namespace Snappet.Infrastructure.Persistence
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ISnappetDbContext _dbContext;
        private readonly IProgressCalculatorService _progressCalculatorService;

        public ExerciseRepository(ISnappetDbContext dbContext, IProgressCalculatorService progressCalculatorService)
        {
            _dbContext = dbContext;
            _progressCalculatorService = progressCalculatorService;
        }

        public IEnumerable<StudentExerciseActivityModel> GetStudentActivity(DateOnly date, int skip = 0, int take = SnappetConstants.PAGE_SIZE)
        {
            var data = _dbContext.ExerciseReports
                .Where(i => DateOnly.FromDateTime(i.SubmitDateTime) == date)
                .GroupBy(x => x.UserId, x => x).ToList();

            return data.Select(x => new StudentExerciseActivityModel
            {
                UserId = x.Key,
                OverallProgress = _progressCalculatorService.CalculateProgress(x.Key, date),
                CorrectAnswersCount = x.Select(i => i.Correct).Count(i => i > 0),
                ExerciseCount = x.Select(i => i.ExerciseId).Count(),
            }).Skip(skip).Take(take).ToList();

        }

        public IEnumerable<ExerciseModel> GetStudentExercises(DateOnly date, int studentId, int skip = 0, int take = SnappetConstants.PAGE_SIZE)
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
