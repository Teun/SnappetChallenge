using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Database.QueryModels;

namespace SchoolMaster.Database.Repositories
{
    public interface IWorkRepository
    {
        Task<ICollection<AggregateResultSet<int, double>>> GetAverageProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<AggregateResultSet<int, double>>> GetMinProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<AggregateResultSet<int, double>>> GetMaxProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<AggregateResultSet<int, double>>> GetAverageDifficultyAsync(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);
    }
}