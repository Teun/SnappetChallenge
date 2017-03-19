using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dashboard.Api;
using Moq;
using Snappet.Reports;
using Common.Logging;
using System.Web.Http.Results;
using System;

namespace Dashboard.Tests.Api
{
    [TestClass]
    public class ReportControllerTests
    {
        private Mock<ILog> _logMock;
        private ReportController _reportController;
        private Mock<IReportFactory> _reportFactoryMock;
        private Mock<IReport> _reportMock;

        [TestInitialize]
        public void Init()
        {
            _reportFactoryMock = new Mock<IReportFactory>();
            _logMock = new Mock<ILog>();
            _reportController = new ReportController(_reportFactoryMock.Object, _logMock.Object);
            _reportMock = new Mock<IReport>();
        }

        [TestMethod]
        public void All_UnknownReport_ReturnsNotFound()
        {
            var result = _reportController.All("UnknownReport");

            var notFound = result as NotFoundResult;
            Assert.IsNotNull(notFound);
        }

        [TestMethod]
        public void All_KnownReport_ReturnsReport()
        {
            const string knownReportName = "KnownReport";
            const string reportContent = "report";
            _reportMock.Setup(r => r.Generate(It.IsAny<string>())).Returns(reportContent);
            _reportFactoryMock.Setup(m => m.Create(knownReportName)).Returns(_reportMock.Object);

            var result = _reportController.All(knownReportName);

            var okResult = result as OkNegotiatedContentResult<object>;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(reportContent, okResult.Content);
        }

        [TestMethod]
        public void All_ExceptionOnReportCreation_ReturnsInternalServerErrorAndLogsException()
        {
            const string reportName = "KnownReport";
            var exceptionThrowOnReportCreation = new Exception();
            _reportFactoryMock.Setup(m => m.Create(reportName)).Throws(exceptionThrowOnReportCreation);

            var result = _reportController.All(reportName);

            var serverError = result as InternalServerErrorResult;
            Assert.IsNotNull(serverError);
            _logMock.Verify(l => l.Error(It.IsAny<string>(), exceptionThrowOnReportCreation));
        }
    }
}
