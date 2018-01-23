using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.Repositories.JSON;

namespace SnappetChallenge.Services.Tests
{
    [TestClass]
    public class WorkResultServiceUT
    {
        [TestMethod]
        public void GetTodayWorkResults()
        {
            var wResult = new WorkResultService(new WorkResultRepository());
            var result = wResult.GetTodayWorkResults();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void GetStudentTodayWorkUT()
        {
            var wResult = new WorkResultService(new WorkResultRepository());
            var result = wResult.GetStudentTodayWork(40274);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        //

        [TestMethod]
        public void GetStudentSummaryUT()
        {
            var wResult = new WorkResultService(new WorkResultRepository());
            var result = wResult.GetStudentSummary(40274, new DateTime(2015, 3, 1, 0, 0, 0), new DateTime(2015, 4, 1, 0, 0, 0));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }


        [TestMethod]
        public void GetStudentSubjectsUT()
        {
            var wResult = new WorkResultService(new WorkResultRepository());
            var result = wResult.GetStudentSubjects(40274, new DateTime(2015, 3, 1, 0, 0, 0), new DateTime(2015, 4, 1, 0, 0, 0));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
