using System.Threading.Tasks;
using FluentAssertions;
using SchoolMaster.Database;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Repositories
{
    public class WorkRepositoryTests : IClassFixture<WorkDbContextFixture>, IClassFixture<DateTimeServiceFixture>
    {
        private readonly DateTimeServiceFixture _dateTimeServiceFixture;
        private readonly WorkDbContext _workDbContext;

        public WorkRepositoryTests(WorkDbContextFixture workDbContextFixture,
            DateTimeServiceFixture dateTimeServiceFixture)
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

        [Fact]
        public async Task GetAverageDifficultyAsync_Should_Return_Four_Rows()
        {
            // arrange
            var repo = new WorkRepository(_workDbContext);
            var fromDate = _dateTimeServiceFixture.FromDate;
            var endDate = _dateTimeServiceFixture.Now;

            // act
            var result = await repo.GetAverageDifficultyAsync(fromDate, endDate);

            // assert
            result.Count.Should().Be(4);
        }

        [Theory]
        [InlineData(default(int))]
        [InlineData(40272)]
        public async Task GetSubmissionCountByUserIdAsync_Should_Return_One_Rows(int userId)
        {
            // arrange
            var repo = new WorkRepository(_workDbContext);
            var fromDate = _dateTimeServiceFixture.FromDate;
            var endDate = _dateTimeServiceFixture.Now;

            // act
            var result = await repo.GetSubmissionCountByUserIdAsync(fromDate, endDate, userId);

            // assert
            result.Count.Should().Be(1);
        }
    }
}