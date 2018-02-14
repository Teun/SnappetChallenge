using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.REST.Service.Controllers;
using Snappet.REST.Service.Tests.Dependency;

namespace Snappet.REST.Service.Tests.Controller
{
    [TestClass]
    public class WorkControllerTest:BaseTest
    {
        [TestMethod]
        public void GetAllResult()
        {
            // Arrange
            WorkController controller = new WorkController(_workManager);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            HttpResponseMessage result = controller.GetStudentResult();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotNull(result.Content);
        }
    }
}
