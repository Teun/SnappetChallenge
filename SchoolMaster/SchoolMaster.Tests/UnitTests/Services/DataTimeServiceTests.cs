using System;
using FluentAssertions;
using SchoolMaster.Services;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Services
{
    public class DataTimeServiceTests : IClassFixture<DateTimeServiceFixture>
    {
        private readonly IDateTimeService _dateTimeService;

        public DataTimeServiceTests(DateTimeServiceFixture dateTimeServiceFixture)
        {
            _dateTimeService = dateTimeServiceFixture.DateTimeService;
        }

        [Fact]
        public void Now_Should_Return_20150324113000Utc()
        {
            // arrange
            var expectedResult = DateTime.SpecifyKind(DateTime.Parse("2015-03-24 11:30:00"), DateTimeKind.Utc);

            // act
            var now = _dateTimeService.Now;

            // assert
            now.Should().BeSameDateAs(expectedResult);
        }

        [Theory]
        [InlineData("2015-03-24 11:29:00")]
        [InlineData("2015-03-24 11:29:59")]
        public void IsDateBeforeNow_Should_Return_True(string dateStr)
        {
            // arrange
            var date = DateTime.SpecifyKind(DateTime.Parse(dateStr), DateTimeKind.Utc);

            // act
            var result = _dateTimeService.IsDateBeforeNow(date);

            // assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("2015-03-24 11:31:00")]
        [InlineData("2015-03-24 11:30:01")]
        public void IsDateBeforeNow_Should_Return_False(string dateStr)
        {
            // arrange
            var date = DateTime.SpecifyKind(DateTime.Parse(dateStr), DateTimeKind.Utc);

            // act
            var result = _dateTimeService.IsDateBeforeNow(date);

            // assert
            result.Should().BeFalse();
        }
    }
}