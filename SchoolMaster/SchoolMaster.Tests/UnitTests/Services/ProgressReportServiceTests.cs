using System;
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
    public class ProgressReportServiceTests : IClassFixture<AutoMapperFixture>
        , IClassFixture<RepositoryFixtures>
        , IClassFixture<DateTimeServiceFixture>
    {
        private readonly DateTimeServiceFixture _dateTimeFixture;
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;

        public ProgressReportServiceTests(AutoMapperFixture mapperFixture
            , RepositoryFixtures repositoryFixtures
            , DateTimeServiceFixture dateTimeServiceFixture)
        {
            _mapper = mapperFixture.Mapper;
            _workRepository = repositoryFixtures.WorkRepository;
            _dateTimeFixture = dateTimeServiceFixture;
        }

        [Fact]
        public async Task GetProgressReportAsync_Should_Return_Data()
        {
            // arrange
            var service = new WorkProgressReportService(_workRepository
                , _dateTimeFixture.DateTimeService);

            // act
            var result = await service.GetProgressReportAsync(_dateTimeFixture.FromDate
                , _dateTimeFixture.Now);

            // assert
            result.Should().NotBeNull();
            result.Average.Count().Should().Be(4);
            result.Maximum.Count().Should().Be(4);
            result.Minimum.Count().Should().Be(4);
        }

        [Fact]
        public async Task GetProgressReportAsync_WhenDateGreaterThanNow_Should_ThrowException()
        {
            // arrange
            var service = new WorkProgressReportService(_workRepository
                , _dateTimeFixture.DateTimeService);

            var dateGreaterThan2015 = DateTime.Now;


            // act
            var exception = await Record.ExceptionAsync(async () =>
            {
                await service.GetProgressReportAsync(_dateTimeFixture.FromDate
                    , dateGreaterThan2015);
            });

            // assert
            exception.Should().NotBeNull();
        }
    }
}