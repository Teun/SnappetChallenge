using Snappet.Domain.Interface.Service;
using Snappet.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.Services
{
    public class ProgressCalculatorService : IProgressCalculatorService
    {
        private readonly DbContext _dbContext;

        public ProgressCalculatorService(DbContext dbContext)
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
