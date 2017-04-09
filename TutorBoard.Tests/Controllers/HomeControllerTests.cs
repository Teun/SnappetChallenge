using Moq;
using System;
using System.Web.Mvc;
using TutorBoard.Controllers;
using TutorBoard.Dal.Providers;
using Xunit;

namespace TutorBoard.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void TestIndex()
        {
            var date = new DateTime(2016, 3, 4);

            var dateTimeProviderMock = new Mock<IDateTimeProvider>();

            // Setup
            dateTimeProviderMock.SetupGet(c => c.UtcNow).Returns(date);

            var controller = new HomeController(dateTimeProviderMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Verify
            dateTimeProviderMock.VerifyGet(c => c.UtcNow, Times.AtLeastOnce);

            Assert.NotNull(result);
            Assert.NotNull(result.ViewBag);
            Assert.Equal("Overzicht 04-03-2016", result.ViewBag.Title);
        }
    }
}
