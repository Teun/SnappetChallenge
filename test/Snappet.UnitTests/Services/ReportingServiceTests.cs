using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Snappet.Web.Persistence;
using Snappet.Web.Persistence.Models;
using Snappet.Web.Services;
using Xunit;

namespace Snappet.UnitTests.Services
{
    public class ReportingServiceTests
    {
        [Fact]
        public async Task ExecuteReportShouldThrowArgumentNullExceptionWhenReportIsNull()
        {
            var db = new Mock<SnappetDbContext>(new DbContextOptions<SnappetDbContext>());

            var service = new ReportingService(db.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteReport(null, null));

        }

        [Fact]
        public async Task ExecuteReportShouldThrowArgumentNullExceptionWhenReportStorageProcedureIsEmpty()
        {
            var db = new Mock<SnappetDbContext>(new DbContextOptions<SnappetDbContext>());

            var service = new ReportingService(db.Object);

            var report = new Report();

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.ExecuteReport(report, null));
        }

        [Fact]
        public async Task ExecuteReportShouldThrowArgumentNullExceptionOnInvalidReportParameters()
        {
            var db = new Mock<SnappetDbContext>(new DbContextOptions<SnappetDbContext>());

            var service = new ReportingService(db.Object);

            var report = new Report
            {
                StorageProcedure = "dbo.StorageProcedure",
                ReportConfiguration = new ReportConfiguration()
                {
                    Parameters = new List<ReportParameter>()
                    {
                        new ReportParameter()
                        {
                            Name = "Test",
                            Type = "string"
                        }
                    }
                }
            };

            var parameters = new Dictionary<string, object>()
            {
                { "Wrong","Parameter"}
            };


            await Assert.ThrowsAsync<ArgumentException>(() =>  service.ExecuteReport(report, parameters));
        }
    }
}
