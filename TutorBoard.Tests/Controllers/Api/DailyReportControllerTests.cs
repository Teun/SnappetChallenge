using Moq;
using System;
using System.Threading.Tasks;
using TutorBoard.Controllers.Api;
using TutorBoard.Dal.Providers;
using TutorBoard.Report.Dtos;
using TutorBoard.Report.Services;
using Xunit;

namespace TutorBoard.Tests.Controllers.Api
{
    public class DailyReportControllerTests
    {

        [Fact]
        public async Task TestGetSingle()
        {
            var date = new DateTime();
            var testReport = new DailyReportDto();

            var reportMock = new Mock<IDailyReportService>();
            var dateTimeProviderMock = new Mock<IDateTimeProvider>();

            // Setup
            dateTimeProviderMock.SetupGet(p => p.UtcNow).Returns(date);
            reportMock.Setup(c => c.CreateDailyReportAsync(date)).Returns(Task.FromResult(testReport));

            var controller = new DailyReportController(reportMock.Object, dateTimeProviderMock.Object);

            // Act
            var result = await controller.Get();

            // Verify
            dateTimeProviderMock.VerifyGet(p => p.UtcNow, Times.AtLeastOnce);
            reportMock.Verify(r => r.CreateDailyReportAsync(date), Times.Once);

            Assert.NotNull(result);
            Assert.Same(testReport, result);
        }
    }
}
