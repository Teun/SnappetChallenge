using System;
using System.Threading.Tasks;
using RReporter.Application.ReportWorkSummary.Dto;

namespace RReporter.Application.ReportWorkSummary
{
    public interface IWorkSummaryQueries
    {
        Task<WorkSummaryDto> GetDaySummaryAtTimeAsync (int classId, DateTime now);
    }
}