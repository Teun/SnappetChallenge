﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet.Web.Persistence.Repositories;
using Snappet.Web.Services;

namespace Snappet.Web.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class ReportingController : Controller
    {
        private IReportingService reportingService;
        private IReportRepository reportRepository;

        public ReportingController(IReportingService reportingService, IReportRepository reportRepository)
        {
            this.reportingService = reportingService;
            this.reportRepository = reportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var reports = await reportRepository.GetReportsAsync();

            var result = reports.Select(
                x => new { id = x.Id, displayName = x.DisplayName }).ToList();

            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportConfiguration(int id)
        {
            var report = await reportRepository.GetReportByIdAsync(id);

            if (report == null)
            {
                return NotFound();
            }


            return new OkObjectResult(new
            {
                id = id,
                displayName = report.DisplayName,
                configuration = new
                {
                    parameters = report.ReportConfiguration.Parameters.Select(x => new
                    {
                        name = x.Name,
                        type = x.Type
                    })
                }
            });
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ExecuteReport(int id, [FromBody] Dictionary<string, object> parameters)
        {
            var report = await reportRepository.GetReportByIdAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            var reportResult = await reportingService.ExecuteReport(report, parameters);

            return new OkObjectResult(reportResult);
        }
    }
}
