using System;
using Xunit;
using SnappetReports.Data.Services;
using SnappetReports;
using SnappetReports.Controllers;
using System.Collections.Generic;
using SnappetReports.Data.Models;

namespace SnappetReports.Tests
{
    public class SnappetReportTest
    {
        [Fact]
        public void GetReportRecordsTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetReportRecords();
            Assert.IsType<List<ReportRecord>>(okResult);            
        }

        [Fact]
        public void GetReportJSONTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetReportJSON();
            Assert.IsType<string>(okResult);
        }

        [Fact]
        public void GetReportJSONNullTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetReportJSON();
            Assert.NotNull(okResult);
        }

        [Fact]
        public void GetSubjectAnswerCountTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetSubjectAnswerCount();
            Assert.IsType<List<SubjectAnswerCount>>(okResult);
        }

        [Fact]
        public void GetUserReportsTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetUserReports();
            Assert.IsType<List<UserReport>>(okResult);
        }

        [Fact]
        public void GetSubjectDailyReportsTest()
        {
            ReportsService reportService = new ReportsService();
            var reportController = new ReportsController(reportService);
            var okResult = reportService.GetSubjectDailyReports();
            Assert.IsType<List<SubjectDailyReport>>(okResult);
        }
    }
}
