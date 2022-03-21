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

        public IEnumerable<ExerciseReportModel> GetDailyReport(DateOnly date)
        {
            return _dbContext.ExerciseReports.Where(i => DateOnly.FromDateTime(i.SubmitDateTime) == date).ToList();
        }
    }
}
