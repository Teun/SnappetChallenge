using Snappet.Domain.Interface;
using Snappet.Domain.Interface.Service;

namespace Snappet.Infrastructure.Services
{
    public class ProgressCalculatorService : IProgressCalculatorService
    {
        private readonly ISnappetDbContext _dbContext;

        public ProgressCalculatorService(ISnappetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CalculateProgress(int userId, DateOnly date)
        {
            var data = _dbContext.ExerciseReports
                .Where(e => e.UserId == userId)
                .Where(e => DateOnly.FromDateTime(e.SubmitDateTime) <= date)
                .Sum(e => e.Progress);
            return data;
        }
    }
}
