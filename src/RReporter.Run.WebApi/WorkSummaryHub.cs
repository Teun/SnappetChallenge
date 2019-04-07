using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RReporter.Application.ReportWorkSummary;
using RReporter.Application.ReportWorkSummary.Dto;
using RReporter.Framework;

namespace RReporter.Run.WebApi 
{
    public class WorkSummaryHub : Hub 
    {
        private readonly IWorkSummaryQueries workSummaryQueries;
        private readonly ITimeProvider timeProvider;

        public WorkSummaryHub(IWorkSummaryQueries workSummaryQueries, ITimeProvider timeProvider)
        {
            this.workSummaryQueries = workSummaryQueries;
            this.timeProvider = timeProvider;
        }

        public Task<WorkSummaryDto> GetWorkSummary(int classId) 
        {
            return workSummaryQueries.GetDaySummaryAtTimeAsync(classId, timeProvider.CurrentUtcTime);
        }

        public DateTime GetCurrentTime() 
        {
            return timeProvider.CurrentUtcTime;
        }
    }
}