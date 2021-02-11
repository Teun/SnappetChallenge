using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Services;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Services
{
    public class SubmissionReportServiceTests : IClassFixture<RepositoryFixtures>
        , IClassFixture<AutoMapperFixture>
        , IClassFixture<DateTimeServiceFixture>
    {
        private readonly DateTimeServiceFixture _dateTimeFixture;
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;

        public SubmissionReportServiceTests(AutoMapperFixture mapperFixture
            , RepositoryFixtures repositoryFixtures
            , DateTimeServiceFixture dateTimeServiceFixture)
        {
            _mapper = mapperFixture.Mapper;
            _workRepository = repositoryFixtures.WorkRepository;
            _dateTimeFixture = dateTimeServiceFixture;
        }

        [Fact]
        public async Task GetSubmissionCountByUserIdAsync_Should_Return_Rows()
        {
            // arrange
            var service = new SubmissionReportService(_workRepository, _dateTimeFixture.DateTimeService, _mapper);

            // act
            var result = await service.GetSubmissionCountByUserIdAsync(_dateTimeFixture.FromDate, _dateTimeFixture.Now);

            // assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }
    }
}