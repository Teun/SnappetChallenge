using Snappet.Data.Context;
using Snappet.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Data
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly SnappetContext _snappetContext;

        public AnswersRepository(SnappetContext snappetContext)
        {
            _snappetContext = snappetContext;
        }

        public bool DataExistsForDate(DateTime date)
        {
            return _snappetContext.SubmittedAnswers.Any(x => x.SubmitDateTime.Date == date.Date);
        }

        public Task<List<AnswerEntity>> GetByDate(DateTime date)
        {
            var statsByDate = _snappetContext.SubmittedAnswers.Where(x => x.SubmitDateTime.Date == date.Date);
            return Task.FromResult(statsByDate.ToList());
        }

        public async Task Insert(AnswerEntity stats)
        {
            await _snappetContext.SubmittedAnswers.AddAsync(stats);
            await _snappetContext.SaveChangesAsync();
        }

        public async Task Insert(IEnumerable<AnswerEntity> stats)
        {
            await _snappetContext.SubmittedAnswers.AddRangeAsync(stats);
            await _snappetContext.SaveChangesAsync();
        }
    }
}
