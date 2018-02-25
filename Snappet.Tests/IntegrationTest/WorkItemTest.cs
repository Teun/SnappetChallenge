using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Core.Dtos;
using Snappet.Repository.Dao;
using Snappet.Repository.Helpers;
using Snappet.Repository.Interfaces;

namespace Snappet.Tests.IntegrationTest
{
    [TestClass]
    public class WorkItemTest
    {
        private IWorkRepository _workRepository; 

        [TestInitialize]
        public void Init()
        {
            _workRepository = new WorkRepository();

        }

        [TestMethod]
        public void FetchWorkItemsTest()
        {
            #region--Arrange --

            QueryResult<WorkItem> result = null;

            #endregion

            #region--Act --

            try
            {
                result = _workRepository.FindAll();
                if (result != null)
                {
                    Trace.WriteLine(string.Format("Fetched Work Items: {0}", result.Result.Count()));
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
            #endregion

            #region--Assert --
            Assert.IsTrue(result != null && result.TotalRecords > 0 && result.Result.Count() == 10);
            #endregion
        } 

        [TestMethod]
        public void FetchWorkItemsByUserTest()
        {
            #region--Arrange --

            QueryResult<WorkItem> result = null;
            const int userId = 40282;
            #endregion

            #region--Act --

            try
            {
                result = _workRepository.FindByUser(userId);
                if (result != null)
                {
                    Trace.WriteLine(string.Format("Fetched Work Items By UserId: {0}", result.TotalRecords));
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
            #endregion

            #region--Assert --
            Assert.IsNotNull(result);
            #endregion
        }

        [TestMethod]
        public void FetchWorkItemsBySubjectTest()
        {
            #region--Arrange --

            QueryResult<WorkItem> result = null;
            const string subject = "Begrijpend Lezen";
            #endregion

            #region--Act --

            try
            {
                result = _workRepository.FindBySubject(subject);
                if (result != null)
                {
                    Trace.WriteLine(string.Format("Fetched Work Items By Subject: {0}", result.TotalRecords));
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
            #endregion

            #region--Assert --
            Assert.IsNotNull(result);
            #endregion
        }
        [TestMethod]
        public void FetchWorkItemsSubjectsTest()
        {
            #region--Arrange --

            QueryResult<string> result = null; 
            #endregion

            #region--Act --

            try
            {
                result = _workRepository.GetAllSubject();
                if (result != null)
                {
                    Trace.WriteLine(string.Format("Fetched Work Items By Subject: {0}", result.TotalRecords));
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message);
            }
            #endregion

            #region--Assert --
            Assert.IsNotNull(result);
            #endregion
        }
    }
}
