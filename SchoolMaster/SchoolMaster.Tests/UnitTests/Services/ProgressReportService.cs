using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq.Language;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Services;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Services
{
    public class ProgressReportService : IClassFixture<Fixtures.AutoMapperFixture>
        , IClassFixture<Fixtures.RepositoryFixtures>
        , IClassFixture<Fixtures.DateTimeServiceFixture>
    {
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;
        private readonly DateTimeServiceFixture _dateTimeFixture;

        public ProgressReportService(AutoMapperFixture mapperFixture
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
            var service = new WorkProgressReportService(_workRepository, _mapper
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
            var service = new WorkProgressReportService(_workRepository, _mapper
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
