using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Snappet.Test.TopStudents.Interface.Dtos;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Data.Implementations
{
    public class DaySummaryQuery : IDaySummaryQuery
    {
        public async Task<DaySummaryDto> GetAsync(string subject, DateTime date)
        {
            DaySummaryDto record;

            using (new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            using (var context = new TopStudentsDbContext())
            {
                record = await context.DaySummaries
                    .AsNoTracking()
                    .Select(s => new DaySummaryDto
                    {
                        Subject = s.Subject,
                        MaxProgress = s.MaxProgress,
                        MinProgress = s.MinProgress,
                        AverageProgress = s.AverageProgress,
                        RecordDate = s.RecordDate,
                        NumberOfAnswers = s.NumberOfAnswers,
                        NumberOfStudents = s.NumberOfStudents
                    })
                    .FirstOrDefaultAsync(r => r.Subject == subject && r.RecordDate == date)
                    .ConfigureAwait(false);
            }

            return record;
        }

        public Task<List<DaySummaryDto>> GetSummariesAsync(DateTime date)
        {
            return InternalGetSummariesAsync(date, date);
        }

        public async Task<List<DaySummaryDto>> InternalGetSummariesAsync(DateTime? start, DateTime? end)
        {
            List<DaySummaryDto> result;

            using (new TransactionScope(TransactionScopeOption.Suppress, TransactionScopeAsyncFlowOption.Enabled))
            using (var context = new TopStudentsDbContext())
            {
                var query = context.DaySummaries
                    .AsNoTracking()
                    .OrderByDescending(r=>r.RecordDate)
                    .ThenBy(r => r.Subject)
                    .AsQueryable();

                if (start.HasValue)
                {
                    query = query.Where(r => r.RecordDate >= start.Value);
                }
                if (end.HasValue)
                {
                    query = query.Where(r => r.RecordDate <= end.Value);
                }

                result = await query
                      .Select(s => new DaySummaryDto
                      {
                          Subject = s.Subject,
                          MaxProgress = s.MaxProgress,
                          MinProgress = s.MinProgress,
                          AverageProgress = s.AverageProgress,
                          RecordDate = s.RecordDate,
                          NumberOfAnswers = s.NumberOfAnswers,
                          NumberOfStudents = s.NumberOfStudents
                      })
                    .ToListAsync()
                    .ConfigureAwait(false);
            }

            return result;
        }

        public Task<List<DaySummaryDto>> GetSummariesAsync()
        {
            return InternalGetSummariesAsync(null, null);
        }
    }
}