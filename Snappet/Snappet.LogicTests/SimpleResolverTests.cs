using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic.Tests
{
    [TestClass()]
    public class SimpleResolverTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            //Arrange
            SimpleResolver.MapType(typeof(IStudentRecordsLogic), typeof(StudentRecordsLogic));
            SimpleResolver.MapType(typeof(IParser), CSVParser.Instance);

            //Act
            var logicObj = SimpleResolver.GetInstance<IStudentRecordsLogic>();
            var parser = SimpleResolver.GetInstance<IParser>();

            //assert
            Assert.ThrowsException<ArgumentException>(() => SimpleResolver.GetInstance(typeof(IAppConfig)));

            Assert.IsNotNull(logicObj);
            Assert.IsInstanceOfType(logicObj, typeof(StudentRecordsLogic));

            Assert.IsNotNull(parser);
            Assert.IsInstanceOfType(parser, typeof(CSVParser));
            Assert.IsTrue(parser == CSVParser.Instance);
        }
    }
}