using Moq;
using Report.Data;
using Report.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Report.Test
{
    public class TodayDashboardApiQueryTest
    {
        [Fact]
        public async Task Should_return_valid_report_when_invoked()
        {
            // Arrange
            var dataContextMock = new Mock<IDataContext>();
            dataContextMock.Setup(m => m.Get()).Returns(Data);
            var dateProviderMock = new Mock<IDateProvider>();
            dateProviderMock.Setup(m => m.Now).Returns(new DateTime(2015, 3, 24, 11, 30, 0, DateTimeKind.Utc));

            var sut = new TodayDashboardApiQuery(dataContextMock.Object, dateProviderMock.Object);

            // Act
            var actual = await sut.Execute();

            // Assert
            Assert.Equal(4, actual.Value.TotalAnswerNumber);
            Assert.Equal(3, actual.Value.TotalUserNumber);
            Assert.Equal("Listening", actual.Value.MostPopularSubject);
        }

        private Task<IEnumerable<UserActivity>> Data =>
             Task.FromResult<IEnumerable<UserActivity>>(new List<UserActivity>
             {
                 new UserActivity(1, new DateTime(2015,3,24,0,0,0, DateTimeKind.Utc), true, 1, 1, 1, 100, "Listening", "Language", "-"),
                 new UserActivity(2, new DateTime(2015,3,25,0,0,0, DateTimeKind.Utc), true, 1, 1, 1, 200, "Listening", "Language", "-"), // after
                 new UserActivity(3, new DateTime(2015,3,24,0,0,0, DateTimeKind.Utc), true, 1, 2, 1, 300, "Listening", "Language", "-"),
                 new UserActivity(4, new DateTime(2015,3,24,0,0,0, DateTimeKind.Utc), true, 0, 1, 1, 200, "Listening", "Language", "-"), // not counted in diff
                 new UserActivity(5, new DateTime(2015,3,24,0,0,0, DateTimeKind.Utc), true, 1, 3, 1, 300, "Reading", "Language", "-"),
             });

    }
}
