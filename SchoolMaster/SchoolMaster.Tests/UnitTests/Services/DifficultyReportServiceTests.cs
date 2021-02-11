using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Services;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Services
{
    public class DifficultyReportServiceTests : IClassFixture<AutoMapperFixture>
        , IClassFixture<RepositoryFixtures>
        , IClassFixture<DateTimeServiceFixture>
    {
        private readonly DateTimeServiceFixture _dateTimeFixture;
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;

        public DifficultyReportServiceTests(AutoMapperFixture mapperFixture
            , RepositoryFixtures repositoryFixtures
            , DateTimeServiceFixture dateTimeServiceFixture)
        {
            _mapper = mapperFixture.Mapper;
            _workRepository = repositoryFixtures.WorkRepository;
            _dateTimeFixture = dateTimeServiceFixture;
        }

        [Fact]
        public async Task GetAverageDifficultyAsync_Should_Return_Data()
        {
            // arrange
            var service = new WorkDifficultyReportService(_workRepository
                , _dateTimeFixture.DateTimeService);

            // act
            var result = await service.GetAverageDifficultyAsync(_dateTimeFixture.FromDate
                , _dateTimeFixture.Now);

            // assert
            result.Should().NotBeNull();
            result.Count().Should().Be(4);
        }
    }
}