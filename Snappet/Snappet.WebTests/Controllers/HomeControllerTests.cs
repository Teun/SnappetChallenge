using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Logic;
using Snappet.Logic.Models;
using Snappet.Web.Controllers;
using Snappet.Web.Tests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Snappet.Web.Controllers.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private void ArrangeServiceLocator()
        {
            SimpleResolver.MapType(typeof(IAppConfig), new TestConfig());
            SimpleResolver.MapType(typeof(IStudentRecordsLogic), typeof(StudentRecordsLogic));
            SimpleResolver.MapType(typeof(IParser), CSVParser.Instance);
        }

        [TestMethod]
        public void GetDayResult()
        {
            // Arrange
            ArrangeServiceLocator();
            HomeController controller = new HomeController();
            DateTime before = new DateTime(2015, 3, 1);
            DateTime inside = new DateTime(2015, 3, 5);
            DateTime after = new DateTime(2015, 3, 28);
            // Act
            ViewResult beforeResult = controller.GetDayResult(before.ToString(HomeController.DATE_FORMAT)) as ViewResult;
            var beforeModel = beforeResult.Model as IEnumerable<StudentProgressRecord>;

            ViewResult insideResult = controller.GetDayResult(inside.ToString(HomeController.DATE_FORMAT)) as ViewResult;
            var insideModel = insideResult.Model as IEnumerable<StudentProgressRecord>;

            ViewResult afterResult = controller.GetDayResult(after.ToString(HomeController.DATE_FORMAT)) as ViewResult;
            var afterModel = afterResult.Model as IEnumerable<StudentProgressRecord>;

            // Assert

            //before
            Assert.IsNotNull(beforeResult);
            Assert.IsNotNull(beforeModel);
            //20 students
            Assert.AreEqual(beforeModel.Count(), 20);
            foreach (var item in beforeModel)
            {
                Assert.AreEqual(item.Progress.Count, 0);
            }

            //inside
            Assert.IsNotNull(insideResult);
            Assert.IsNotNull(insideModel);
            //20 students
            Assert.AreEqual(insideModel.Count(), 20);
            Assert.IsTrue(insideModel.Any(s => s.Progress.Count > 0));
            Assert.IsTrue(insideModel.Any(s => s.Exercises.Count > 0));

            //after
            Assert.IsNotNull(afterResult);
            Assert.IsNotNull(afterModel);
            //20 students
            Assert.AreEqual(afterModel.Count(), 20);
            foreach (var item in afterModel)
            {
                Assert.AreEqual(item.Progress.Count, 0);
            }

            SimpleResolver.Clear();
        }

        [TestMethod]
        public void GetStudentProgressDetails()
        {
            // Arrange
            ArrangeServiceLocator();
            HomeController controller = new HomeController();
            DateTime from = new DateTime(2015, 3, 2);
            DateTime to = new DateTime(2015, 3, 24);

            // Act
            JsonResult result = controller.GetStudentProgressDetails(40267, from.ToString(HomeController.DATE_FORMAT),
                                                to.ToString(HomeController.DATE_FORMAT)) as JsonResult;

            //Assert
            Assert.IsNotNull(result);
            //get daysProgress using reflection
            var daysProgress = result.Data.GetType().GetProperties()[0].GetValue(result.Data) as List<double>;
            Assert.IsNotNull(daysProgress);
            //make sure the logic skips 6 week end days between 2nd of march, and the 24th
            Assert.AreEqual(daysProgress.Count, 17);
            //no student with ID zero
            Assert.ThrowsException<KeyNotFoundException>(() => controller.GetStudentProgressDetails(0, from.ToString(HomeController.DATE_FORMAT),
                                               to.ToString(HomeController.DATE_FORMAT)));
            //check that to has to be after before
            Assert.ThrowsException<ArgumentException>(() => controller.GetStudentProgressDetails(40267, to.ToString(HomeController.DATE_FORMAT),
                                                from.ToString(HomeController.DATE_FORMAT)));

            SimpleResolver.Clear();
        }
    }
}