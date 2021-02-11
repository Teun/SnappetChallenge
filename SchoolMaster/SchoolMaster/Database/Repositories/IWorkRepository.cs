using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Database.QueryModels;

namespace SchoolMaster.Database.Repositories
{
    public interface IWorkRepository
    {
        Task<ICollection<HourValuePair>> GetAverageProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<HourValuePair>> GetMinProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<HourValuePair>> GetMaxProgress(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<HourValuePair>> GetAverageDifficultyAsync(DateTime from, DateTime end,
            CancellationToken cancellationToken = default);

        Task<ICollection<SubmissionCount>> GetSubmissionCountByUserIdAsync(DateTime from, DateTime end,
            int userId = default,
            CancellationToken cancellationToken = default);
    }
}