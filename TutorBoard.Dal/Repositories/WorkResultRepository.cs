using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Models;

namespace TutorBoard.Dal.Repositories
{
    public class WorkResultRepository : IWorkResultRepository
    {
        private readonly IDataContext _dataContext;

        public WorkResultRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        /// <inheritdoc />
        public Task<int> CountExercisesAsync(DateTime date)
        {
            return Task.FromResult(_dataContext.GetWorkData()
                .AsParallel()
                .Where(w => w.SubmitDateTime.Date == date.Date)
                .GroupBy(w => Tuple.Create(w.UserId, w.ExerciseId))
                .Count());
        }

        /// <inheritdoc />
        public Task<int> CountExercisesForSubjectAsync(DateTime date, string subject)
        {
            return Task.FromResult(_dataContext.GetWorkData()
                .AsParallel()
                .Where(w => w.SubmitDateTime.Date == date.Date)
                .Where(w => string.Equals(w.Subject, subject, StringComparison.InvariantCulture))
                .GroupBy(w => Tuple.Create(w.UserId, w.ExerciseId))
                .Count());
        }

        /// <inheritdoc />
        public Task<IEnumerable<UserProgress>> GetUserProgressAsync(DateTime date)
        {
            return Task.FromResult<IEnumerable<UserProgress>>(_dataContext.GetWorkData()
                .AsParallel()
                .Where(w => w.SubmitDateTime.Date == date.Date)
                .GroupBy(w => w.UserId)
                .Select(w => new UserProgress { UserId = w.Key, Progress = w.Sum(p => p.Progress) })
                .ToList());
        }
    }
}
