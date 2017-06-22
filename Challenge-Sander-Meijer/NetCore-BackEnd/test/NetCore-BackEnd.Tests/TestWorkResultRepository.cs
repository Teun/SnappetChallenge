using System;
using System.Collections.Generic;
using Moq;
using NetCore.BackEnd.Models.Poco;
using NetCore.BackEnd.Repositories;
using Xunit;

namespace NetCore.BackEnd.Tests
{
	public class TestWorkResultRepository
	{
		private IDataContext GenerateMockDataContext()
		{
			var mockDataContext = new Mock<IDataContext>();
			var workResults = new List<WorkResult>();


			for (var i = 0; i < 10; i++)
			{
				workResults.Add(new WorkResult
				{
					SubmitDateTime = DateTime.Now.AddDays(-i)
				});
			}

			mockDataContext.SetupGet(dataContext => dataContext.WorkResults).Returns(workResults);
			return mockDataContext.Object;
		}

		[Fact]
		public void TestGetWorkResultsForPeriod()
		{
			// Arrange
			var mockDataContext = GenerateMockDataContext();
			var repository = new WorkResultRepository(mockDataContext);

			// Act
			var results = repository.GetWorkResultsForPeriod(DateTime.Now.AddDays(-1.5), DateTime.Now);

			// Assert
			Assert.NotNull(results);
			Assert.Equal(2, results.Count);
		}

		[Fact]
		public void TestGetWorkResultsForPeriodGetAll()
		{
			// Arrange
			var mockDataContext = GenerateMockDataContext();
			var repository = new WorkResultRepository(mockDataContext);

			// Act
			var results = repository.GetWorkResultsForPeriod(DateTime.MinValue, DateTime.MaxValue);

			// Assert
			Assert.NotNull(results);
			Assert.Equal(10, results.Count);
		}
	}
}