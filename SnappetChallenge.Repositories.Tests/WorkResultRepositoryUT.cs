using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.Repositories.JSON;

namespace SnappetChallenge.Repositories.JSON.Tests
{
    [TestClass]
    public class WorkResultRepositoryUT
    {

        [TestMethod]
        public void GetAllLearningObjectiveTest()
        {
            var wResult = new WorkResultRepository();
            var result = wResult.GetLearningObjectivesBySubjectAndDomain("Rekenen", "Meten");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetDomainsBySubjectTest()
        {
            var wResult = new WorkResultRepository();
            var result = wResult.GetDomainsBySubject("Rekenen");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
        [TestMethod]
        public void GetAllSubjectsTest()
        {
            var wResult = new WorkResultRepository();
            var result = wResult.GetAllSubjects();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void SearchWorkResultsTest()
        {
            var wResult = new WorkResultRepository();
            var result = wResult.SearchWorkResults(new DateTime(2015, 3, 24, 0, 0, 0), new DateTime(2015, 3, 24, 23, 59, 59), true,null,null,null, "Rekenen", string.Empty, string.Empty);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
