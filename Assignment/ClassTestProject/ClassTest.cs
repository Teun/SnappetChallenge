#region Imports
using System;
using System.Collections.Generic;
using System.IO;
using Assignment.DAL;
using Assignment.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
#endregion

#region namespace
namespace ClassTestProject
{
    #region TestClass
    [TestClass]
    public class ClassTest
    {
        private static List<JsonDataModel> jsonData;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var formjson = File.ReadAllText("work.json");
             jsonData = JsonConvert.DeserializeObject<List<JsonDataModel>>(formjson);
           
        }
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            if (jsonData != null)
            {
                jsonData = null;
            }
        }
        #region TestMethod
        [TestMethod]
        public void TestCurrentUserIdCount()
        {
            var objcls = new ClassDAL();
            var result = objcls.ClassData(jsonData);
            Assert.IsTrue(result.CurrentUserIdCount > 0);
        }

        [TestMethod]
        public void TestCurrentExerciseIdCount()
        {
            var objcls = new ClassDAL();
            var result = objcls.ClassData(jsonData);
            Assert.IsTrue(result.CurrentExerciseIdCount > 0);
        }

        [TestMethod]
        public void TestCurrentCorrectCount()
        {
            var objcls = new ClassDAL();
            var result = objcls.ClassData(jsonData);
            Assert.IsTrue(result.CurrentCorrectCount > 0);
        }

        [TestMethod]
        public void TestCurrentInCorrectCount()
        {
            var objcls = new ClassDAL();
            var result = objcls.ClassData(jsonData);
            Assert.IsTrue(result.CurrentInCorrectCount > 0);
        }
        #endregion
    }
    #endregion
}

#endregion
