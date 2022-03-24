using FluentAssertions;
using Snappet.Infrastructure.Services;
using Snappet.Test.Mocks;
using System;
using Xunit;

namespace Snappet.Test
{
    public class CoreTests
    {
        [Fact]
        public void Test1()
        {
            // arange
            var userId = 543;
            var dbContext = new DbContextMock();
            var progressCalculatorService = new ProgressCalculatorService(dbContext);
            // act
            var progress = progressCalculatorService.CalculateProgress(userId, DateOnly.FromDateTime(new DateTime(2015, 3, 15)));
            // assert
            progress.Should().Be(63);
        }
    }
}
