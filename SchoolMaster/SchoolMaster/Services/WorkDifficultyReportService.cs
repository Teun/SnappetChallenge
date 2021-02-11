using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Database.QueryModels;
using SchoolMaster.Database.Repositories;

namespace SchoolMaster.Services
{
    public class WorkDifficultyReportService : IWorkDifficultyReportService
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IWorkRepository _workRepository;

        public WorkDifficultyReportService(IWorkRepository workRepository, IDateTimeService dateTimeService)
        {
            _workRepository = workRepository;
            _dateTimeService = dateTimeService;
        }

        public async Task<ICollection<HourValuePair>> GetAverageDifficultyAsync(DateTime startDate
            , DateTime endDate
            , CancellationToken cancellationToken = default)
        {
            startDate = startDate.ToUniversalTime();
            endDate = endDate.ToUniversalTime();

            if (!_dateTimeService.IsDateBeforeNow(startDate) || !_dateTimeService.IsDateBeforeNow(endDate))
                throw new ArgumentException("Dates cannot be larger than now!");

            return await _workRepository.GetAverageDifficultyAsync(startDate, endDate, cancellationToken);
        }
    }
}