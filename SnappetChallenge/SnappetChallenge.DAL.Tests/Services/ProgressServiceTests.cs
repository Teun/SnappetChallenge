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
    public class ProgressServiceTests
    {
        [TestMethod]
        public void Test01()
        {
            var fromDate = new DateTime(2015, 3, 24, 11, 30, 00);
            var toDate = DateTime.Now;
            var workMock = new Mock<IWorkRepository>();
            var returnValue = new List<Work>();
            workMock.Setup(x => x.GetByDate(It.Is<DateTime>(fd => fd == fromDate), It.Is<DateTime>(td => td == toDate))).Returns(returnValue);
            var service = new ProgressService(workMock.Object);
            var value = service.GetAssignments(fromDate, toDate);
            Assert.AreEqual(0, value.Count());
        }

        [TestMethod]
        public void Test02()
        {
            var fromDate = new DateTime(2015, 3, 24, 11, 30, 00);
            var toDate = DateTime.Now;
            var workMock = new Mock<IWorkRepository>();
            var returnValue = new List<Work>()
            {
                new Work{ UserId=1234, Correct=3, Difficulty=10, SubmitDateTime = fromDate},
                new Work{ UserId=1235,Correct=0, Difficulty=20, SubmitDateTime = fromDate}
            };
            workMock.Setup(x => x.GetByDate(It.Is<DateTime>(fd => fd == fromDate), It.Is<DateTime>(td => td == toDate))).Returns(returnValue);
            var service = new ProgressService(workMock.Object);
            var value = service.GetAssignments(fromDate, toDate);
            Assert.AreEqual(2, value.Count());
            Assert.AreEqual(3, value.FirstOrDefault(w => w.UserId == 1234).TotalAssignments);
            Assert.AreEqual(3, value.FirstOrDefault(w => w.UserId == 1234).CorrectAssignments);
            Assert.AreEqual(0, value.FirstOrDefault(w => w.UserId == 1234).IncorrectAssignments);

            Assert.AreEqual(3, value.FirstOrDefault(w => w.UserId == 1235).TotalAssignments);
            Assert.AreEqual(0, value.FirstOrDefault(w => w.UserId == 1235).CorrectAssignments);
            Assert.AreEqual(3, value.FirstOrDefault(w => w.UserId == 1235).IncorrectAssignments);
        }
    }
}
