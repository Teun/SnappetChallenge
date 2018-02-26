using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Services.Services;

namespace Snappet.Tests.FileHelperTest
{
    [TestClass]
    public class LoadFileTest
    {
        private WorkService _workService;
        private string _path;

        [TestInitialize]
        public void Init()
        {
            _workService = new WorkService();
            _path = AppDomain.CurrentDomain.BaseDirectory + "\\resources\\work.csv";
        }

        [TestMethod]
        public void LoadAndDataFileTest()
        {
            #region--Arrange --
            #endregion

            #region--Act --
            var dataTable = _workService.LoadAndDataFile(_path);
            Trace.WriteLine(string.Format("Columns in the Table: {0}", dataTable.Columns.Count));
            #endregion

            #region--Assert --
            Assert.AreEqual(dataTable.Columns.Count, 10);
            #endregion
        }


        [TestMethod]
        public void DisplayASpecificLineTest()
        {
            #region--Arrange --
            #endregion

            #region--Act --
            var dataTable = _workService.LoadAndDataFile(_path);
            Trace.WriteLine(string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                dataTable.Columns[0], dataTable.Columns[1], dataTable.Columns[2], dataTable.Columns[3],
                dataTable.Columns[4], dataTable.Columns[5], dataTable.Columns[6], dataTable.Columns[7],
                dataTable.Columns[8], dataTable.Columns[9]));
            Trace.WriteLine("============================================"); 

            #endregion

            #region--Assert --
            Assert.AreEqual(dataTable.Columns.Count, 10);
            #endregion
        }
    }
}
