using System;
using Snappet_challenge_api.Models;
using Snappet_challenge_api.Services;
using Xunit;

namespace Snappet_challenge_tests
{
    public class SummaryDataServiceTests
    {
        [Theory]
        [InlineData(10,5, 50)]
        [InlineData(40, 10, 25)]
        [InlineData(100,100, 100)]
        public void PassingCalculateAggregateTest(int questionsAnswered, int answeredCorrectly, float expectedAggregate)
        {
            var subjectSummary = new SubjectSummary("Test", questionsAnswered, answeredCorrectly, 0);

            Assert.Equal(subjectSummary.Aggregate, expectedAggregate);
        }
    }
}
