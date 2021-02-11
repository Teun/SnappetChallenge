using System;
using System.Threading;
using System.Threading.Tasks;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public interface IWorkProgressReportService
    {
        Task<ProgressReportDto> GetProgressReportAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    }
}