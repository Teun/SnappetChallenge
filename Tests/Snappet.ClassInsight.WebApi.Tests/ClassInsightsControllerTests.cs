using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Snappet.ClassInsights.Business.Services;
using Snappet.ClassInsights.Model.Dto;
using Snappet.ClassInsights.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snappet.ClassInsights.WebApi.Tests
{

    [TestClass]
    public class ClassInsightsControllerTests
    {
        [TestMethod]
        public async Task GetPubilsDailyInsighWithDateReturnsOKResult()
        {
            // Arrange
            var day = DateTime.Now;
            var insightsServiceMock = new Mock<IInsightsService>();
            insightsServiceMock.Setup(repo => repo.GetPubilsDailyInsightsAsync(day))
                .ReturnsAsync(new List<PubilDailyInsight>{
                    new PubilDailyInsight
                    {
                        CountOfSubmittedAnswers=2,
                        NumberOfCorrectAnswers=1,
                        Domain="d",
                        PubilId=1,
                        Subject="s"
                    }
                });
            var controller = new ClassInsightsController(insightsServiceMock.Object, new Mock<ILogger<ClassInsightsController>>().Object);

            // Act
            var result = await controller.GetPubilsDailyInsightAsync(day);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeOfType<List<PubilDailyInsight>>();
        }
        [TestMethod]
        public async Task GetPubilsDailyInsighWithFaultyServiceRetruns500AndLogsError()
        {
            // Arrange
            var day = DateTime.Now;
            var insightsServiceMock = new Mock<IInsightsService>();
            var exception = new Exception("Message");
            insightsServiceMock.Setup(repo => repo.GetPubilsDailyInsightsAsync(day))
                .ThrowsAsync(exception);
            var loggerMock = new Mock<ILogger<ClassInsightsController>>();
            var controller = new ClassInsightsController(insightsServiceMock.Object, loggerMock.Object);

            // Act
            var result = await controller.GetPubilsDailyInsightAsync(day);

            // Assert
            var statusCodeResult = result.Should().BeOfType<StatusCodeResult>().Subject;
            statusCodeResult.StatusCode.Should().Be(500);
            loggerMock.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), exception, It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }
    }
}
