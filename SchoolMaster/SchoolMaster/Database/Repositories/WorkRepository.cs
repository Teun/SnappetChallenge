using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
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

        public async Task<ICollection<AggregateResultSet<int, double>>> GetAverageProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new AggregateResultSet<int, double>
                {
                    Name = g.Key,
                    Value = g.Average(k => k.Progress)
                })
                .OrderBy(r => r.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<AggregateResultSet<int, double>>> GetMinProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new AggregateResultSet<int, double>
                {
                    Name = g.Key,
                    Value = g.Min(k => k.Progress)
                })
                .OrderBy(r => r.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<AggregateResultSet<int, double>>> GetMaxProgress(
            DateTime from,
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new AggregateResultSet<int, double>
                {
                    Name = g.Key,
                    Value = g.Max(k => k.Progress)
                })
                .OrderBy(r => r.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<AggregateResultSet<int, double>>> GetAverageDifficultyAsync(
            DateTime from, 
            DateTime end,
            CancellationToken cancellationToken = default)
        {
            return await DbContext.UserWorks
                .Where(uw => uw.SubmitDateTime >= from && uw.SubmitDateTime <= end && uw.Difficulty != null)
                .GroupBy(uw => uw.SubmitDateTime.Hour)
                .Select(g => new AggregateResultSet<int, double>
                {
                    Name = g.Key,
                    Value = g.Average(k => k.Difficulty.Value)
                })
                .OrderBy(r => r.Name)
                .ToListAsync(cancellationToken);
        }
    }
}