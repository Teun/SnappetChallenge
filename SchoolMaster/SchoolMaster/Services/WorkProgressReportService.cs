using System;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public class WorkProgressReportService : IWorkProgressReportService
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IWorkRepository _repository;

        public WorkProgressReportService(IWorkRepository repository, IDateTimeService dateTimeService)
        {
            _repository = repository;
            _dateTimeService = dateTimeService;
        }

        public async Task<ProgressReportDto> GetProgressReportAsync(DateTime startDate, DateTime endDate,
            CancellationToken cancellationToken = default)
        {
            startDate = startDate.ToUniversalTime();
            endDate = endDate.ToUniversalTime();

            if (!_dateTimeService.IsDateBeforeNow(startDate) || !_dateTimeService.IsDateBeforeNow(endDate))
                throw new ArgumentException("Dates cannot be larger than now!");

            return new ProgressReportDto
            {
                Average = await _repository.GetAverageProgress(startDate, endDate, cancellationToken),
                Maximum = await _repository.GetMaxProgress(startDate, endDate, cancellationToken),
                Minimum = await _repository.GetMinProgress(startDate, endDate, cancellationToken)
            };
        }
    }
}