using System;
using TutorBoard.Dal.Providers;
using Xunit;

namespace TutorBoard.Dal.Tests.Providers
{
    public class FakeDateTimeProviderTests
    {
        [Fact]
        public void TestGetUtcNow()
        {
            var date = new DateTime(2015, 5, 8, 4, 15, 59);

            // Setup
            var dateTimeProvider = new FakeDateTimeProvider(date);

            // Act
            var result = dateTimeProvider.UtcNow;

            // Verify
            Assert.Equal(date, result);
        }
    }
}
