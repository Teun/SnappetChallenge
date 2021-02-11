using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Database.QueryModels;

namespace SchoolMaster.Services
{
    public interface IWorkDifficultyReportService
    {
        Task<ICollection<AggregateResultSet<int, double>>> GetAverageDifficultyAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    }
}