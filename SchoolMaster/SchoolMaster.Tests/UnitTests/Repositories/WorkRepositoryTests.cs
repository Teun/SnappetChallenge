using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SchoolMaster.Database;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests
{
    public class WorkRepositoryTests : IClassFixture<WorkDbContextFixture>, IClassFixture<DateTimeServiceFixture>
    {
        private readonly WorkDbContext _workDbContext;
        private readonly DateTimeServiceFixture _dateTimeServiceFixture;

        public WorkRepositoryTests(WorkDbContextFixture workDbContextFixture, DateTimeServiceFixture dateTimeServiceFixture)
        {
            _workDbContext = workDbContextFixture.DbContext;
            _dateTimeServiceFixture = dateTimeServiceFixture;
        }

        [Fact]
        public async Task GetAverageProgress_Should_Return_Four_Rows()
        {
            // arrange
            var repo = new WorkRepository(_workDbContext);
            var fromDate = _dateTimeServiceFixture.FromDate;
            var endDate = _dateTimeServiceFixture.Now;

            // act
            var result = await repo.GetAverageProgress(fromDate, endDate);

            // assert
            result.Count.Should().Be(4);
        }

        [Fact]
        public async Task GetMinProgress_Should_Return_Four_Rows()
        {
            // arrange
            var repo = new WorkRepository(_workDbContext);
            var fromDate = _dateTimeServiceFixture.FromDate;
            var endDate = _dateTimeServiceFixture.Now;

            // act
            var result = await repo.GetMinProgress(fromDate, endDate);

            // assert
            result.Count.Should().Be(4);
        }

        [Fact]
        public async Task GetMaxProgress_Should_Return_Four_Rows()
        {
            // arrange
            var repo = new WorkRepository(_workDbContext);
            var fromDate = _dateTimeServiceFixture.FromDate;
            var endDate = _dateTimeServiceFixture.Now;

            // act
            var result = await repo.GetMinProgress(fromDate, endDate);

            // assert
            result.Count.Should().Be(4);
        }
    }
}
