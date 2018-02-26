using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Repository.Dao;
using Snappet.Services.Services;

namespace Snappet.Tests.IntegrationTest
{
    [TestClass]
    public class BulkInsertTest
    {
        private WorkService _workService;
        private WorkRepository _workRepository;
        private string _path;

        [TestInitialize]
        public void Init()
        {
            _workService = new WorkService();
            _workRepository = new WorkRepository();

            _path = AppDomain.CurrentDomain.BaseDirectory + "\\resources\\work.csv";
        }

        [TestMethod]
        public void BulkSqlInsertTest()
        {
            #region--Arrange --

            var result = false;
            #endregion

            #region--Act --
            var dataTable = _workService.LoadAndDataFile(_path);
            try
            {
                _workRepository.BulkInsert(dataTable);
                Trace.WriteLine(string.Format("Successfully Uploaded: {0}", dataTable.Rows.Count));
                result = true;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
            #endregion

            #region--Assert --
            Assert.IsTrue(result);
            #endregion
        }
    }
}
