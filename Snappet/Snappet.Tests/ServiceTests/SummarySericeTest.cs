using Snappet.Entities.Entities;
using Snappet.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Snippet.Tests
{
    public class SummarySericeTest
    {
        #region Private Properties

        /// <summary>
        /// Summary service
        /// </summary>
        private ISummaryService summaryService { get; set; }

        #endregion

        #region Constructer

        public SummarySericeTest()
        {
            //summaryService = new SummaryService();
           
        }

        #endregion

        ///// <summary>
        ///// Given that I am a teacher 
        ///// And I want to view summary of the students in the class
        ///// Then I should be able to see all the list of summary for all the students
        ///// </summary>
        //[Fact]
        //public void LoadAllSummary_Success()
        //{
        //    // Arrange 
        //    string path = AppDomain.CurrentDomain.BaseDirectory;
        //  //  summaryService.JsonFile = @"../../../TestData/test.json";

        //    // Act
        //  //  IEnumerable<Summary> summaries = summaryService.LoadAllSummary();

        //    // Assert
        //    Assert.NotNull(summaries);
        //    Assert.Equal(expected: 149, actual: summaries.Count());
        //}
    }
}
