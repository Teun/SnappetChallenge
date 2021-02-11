using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public interface ISubmissionReportService
    {
        Task<ICollection<SubmissionCountDto>> GetSubmissionCountByUserIdAsync(DateTime startDate, DateTime endDate,
            int userId = default, CancellationToken cancellationToken = default);
    }
}