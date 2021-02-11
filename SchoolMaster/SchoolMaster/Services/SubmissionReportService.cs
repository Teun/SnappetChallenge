using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public class SubmissionReportService : ISubmissionReportService
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;

        public SubmissionReportService(IWorkRepository workRepository, IDateTimeService dateTimeService, IMapper mapper)
        {
            _workRepository = workRepository;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        public async Task<ICollection<SubmissionCountDto>> GetSubmissionCountByUserIdAsync(DateTime startDate,
            DateTime endDate, int userId = default, CancellationToken cancellationToken = default)
        {
            startDate = startDate.ToUniversalTime();
            endDate = endDate.ToUniversalTime();

            if (!_dateTimeService.IsDateBeforeNow(startDate) || !_dateTimeService.IsDateBeforeNow(endDate))
                throw new ArgumentException("Dates cannot be larger than now!");

            var report =
                await _workRepository.GetSubmissionCountByUserIdAsync(startDate, endDate, userId, cancellationToken);
            return _mapper.Map<ICollection<SubmissionCountDto>>(report);
        }
    }
}