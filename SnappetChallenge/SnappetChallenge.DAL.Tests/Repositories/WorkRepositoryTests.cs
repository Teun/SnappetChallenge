using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnappetChallenge.DAL.Repositories;
using SnappetChallenge.DAL.Repositories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Tests.Repositories
{
    [TestClass]
    public class WorkRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(NoWorkFileException))]
        public void LoadDataTest01()
        {
            var workRepo = WorkRepository.LoadData("does_not_exist.json");
        }

        [TestMethod]
        public void LoadDataTest02()
        {
            var workRepo = WorkRepository.LoadData("../../../../Data/work.json");
            Assert.AreEqual(9099, workRepo.GetByDate(new DateTime(2015, 3, 24, 11, 30, 00), DateTime.Now).Count());
        }

        [TestMethod]
        public void LoadDataTest03()
        {
            var workRepo = WorkRepository.LoadData("../../../../Data/work.json");
            Assert.AreEqual(0, workRepo.GetByDate(new DateTime(2016, 1, 1, 11, 30, 00), new DateTime(2017, 1, 1, 11, 30, 00)).Count());
        }

        [TestMethod]
        public void LoadDataTest04()
        {
            var workRepo = WorkRepository.LoadData("../../../../Data/work.json");
            Assert.AreEqual(28713, workRepo.GetByDate(DateTime.MinValue, new DateTime(2015, 3, 24, 11, 30, 00)).Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LoadDataTest05()
        {
            var workRepo = WorkRepository.LoadData("../../../../Data/work.json");
            Assert.AreEqual(28713, workRepo.GetByDate(DateTime.MaxValue, DateTime.MinValue).Count());
        }
    }
}
