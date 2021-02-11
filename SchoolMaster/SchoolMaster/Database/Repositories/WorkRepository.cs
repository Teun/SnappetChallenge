using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolMaster.Database.QueryModels;
using SchoolMaster.Models;

namespace SchoolMaster.Database.Repositories
{
    public class WorkRepository : BaseRepository, IWorkRepository
    {
        public WorkRepository(WorkDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<HourValuePair>> GetAverageProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new HourValuePair
                {
                    Hour = g.Key,
                    Value = g.Average(k => k.Progress)
                })
                .OrderBy(r => r.Hour)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<HourValuePair>> GetMinProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new HourValuePair
                {
                    Hour = g.Key,
                    Value = g.Min(k => k.Progress)
                })
                .OrderBy(r => r.Hour)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<HourValuePair>> GetMaxProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new HourValuePair
                {
                    Hour = g.Key,
                    Value = g.Max(k => k.Progress)
                })
                .OrderBy(r => r.Hour)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<HourValuePair>> GetAverageDifficultyAsync(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end && uw.Difficulty != null)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new HourValuePair
                {
                    Hour = g.Key,
                    Value = g.Average(k => k.Difficulty.Value)
                })
                .OrderBy(r => r.Hour)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<SubmissionCount>> GetSubmissionCountByUserIdAsync(
            DateTime from,
            DateTime end,
            int userId = default,
            CancellationToken cancellationToken = default)
        {
            Expression<Func<Work, bool>> predicate = w => userId == default || w.UserId == userId;

            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .Where(predicate)
                .GroupBy(uw => new {uw.Domain, uw.Subject})
                .Select(g => new SubmissionCount
                {
                    Count = g.Count(),
                    Domain = g.Key.Domain,
                    Subject = g.Key.Subject
                })
                .OrderBy(r => r.Domain)
                .ThenBy(r => r.Subject)
                .ToListAsync(cancellationToken);
        }
    }
}