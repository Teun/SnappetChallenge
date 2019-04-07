using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RReporter.Application.ReportWorkSummary;
using RReporter.Application.ReportWorkSummary.Dto;
using RReporter.Framework;

namespace RReporter.Run.WebApi
{
    public class WorkSummaryController: ControllerBase
    {

        private readonly IWorkSummaryQueries workSummaryQueries;
        private readonly ITimeProvider timeProvider;

        public WorkSummaryController(IWorkSummaryQueries workSummaryQueries, ITimeProvider timeProvider)
        {
            this.workSummaryQueries = workSummaryQueries;
            this.timeProvider = timeProvider;
        }

        public Task<WorkSummaryDto> GetWorkSummary(int classId) 
        {
            return workSummaryQueries.GetDaySummaryAtTimeAsync(classId, timeProvider.CurrentUtcTime);
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get (int classId)
        {
            var result = await workSummaryQueries.GetDaySummaryAtTimeAsync(classId, timeProvider.CurrentUtcTime);
            return result == null ? (ActionResult) NotFound() : Ok(result);
        }

    }
}