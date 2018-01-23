using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.Repositories.JSON;
using SnappetChallenge.Services;
using SnappetChallenge.WebApp;
using SnappetChallenge.WebApp.Controllers;

namespace SnappetChallenge.WebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ClassController controller = new ClassController(new WorkResultService(new WorkResultRepository()));

            // Act
            ViewResult result = controller.TodayWork() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        
    }
}
