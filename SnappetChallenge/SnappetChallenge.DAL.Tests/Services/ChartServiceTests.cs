using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Repositories.Contracts;
using SnappetChallenge.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Tests.Services
{
    [TestClass]
    public class ChartServiceTests
    {
        [TestMethod]
        public void CreateDifficultyChartTest01()
        {
            var fromDate = new DateTime(2015, 3, 24, 11, 30, 00);
            var toDate = DateTime.Now;
            var workMock = new Mock<IWorkRepository>();
            var returnValue = new List<Work>();
            workMock.Setup(x => x.GetByDate(It.Is<DateTime>(fd => fd == fromDate), It.Is<DateTime>(td => td == toDate))).Returns(returnValue);
            var service = new ChartService(workMock.Object);
            var value= service.CreateDifficultyChart(fromDate, toDate);
            Assert.AreEqual(0, value.Labels.Count());
            Assert.AreEqual(3, value.DataSets.Count());
        }

        [TestMethod]
        public void CreateDifficultyChartTest02()
        {
            var fromDate = new DateTime(2015, 3, 24, 11, 30, 00);
            var toDate = DateTime.Now;
            var workMock = new Mock<IWorkRepository>();
            var returnValue = new List<Work>()
            {
                new Work{ Correct=3, Difficulty=10, SubmitDateTime = fromDate},
                new Work{ Correct=0, Difficulty=20, SubmitDateTime = fromDate}
            };
            workMock.Setup(x => x.GetByDate(It.Is<DateTime>(fd => fd == fromDate), It.Is<DateTime>(td => td == toDate))).Returns(returnValue);
            var service = new ChartService(workMock.Object);
            var value = service.CreateDifficultyChart(fromDate, toDate);
            Assert.AreEqual(1, value.Labels.Count());
            Assert.AreEqual(3, value.DataSets.Count());
            Assert.AreEqual(3, value.DataSets["correct"].First());
            Assert.AreEqual(3, value.DataSets["incorrect"].First());
            Assert.AreEqual(15, value.DataSets["avgDiff"].First());
        }
    }
}
