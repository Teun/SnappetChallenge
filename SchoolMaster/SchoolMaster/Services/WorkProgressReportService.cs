using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public class WorkProgressReportService : IWorkProgressReportService
    {
        private readonly IWorkRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public WorkProgressReportService(IWorkRepository repository, IMapper mapper, IDateTimeService dateTimeService)
        {
            _repository = repository;
            _mapper = mapper;
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
