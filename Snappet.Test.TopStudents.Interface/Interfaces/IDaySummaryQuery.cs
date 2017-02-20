using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Snappet.Test.TopStudents.Interface.Dtos;

namespace Snappet.Test.TopStudents.Interface.Interfaces
{
    public interface IDaySummaryQuery
    {
        Task<DaySummaryDto> GetAsync(string subject, DateTime date);
        Task<List<DaySummaryDto>> GetSummariesAsync(DateTime date);
        Task<List<DaySummaryDto>> GetSummariesAsync();
    }
}