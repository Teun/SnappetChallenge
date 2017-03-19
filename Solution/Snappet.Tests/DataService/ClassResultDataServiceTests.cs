using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using Snappet.Data.DataObjects;
using Snappet.Data.DataServices;
using Snappet.Data.Mappers;
using Snappet.Data.QueryRepositories;
using Xunit;

namespace Snappet.Tests.DataService
{
    public class ClassResultDataServiceTests
    {
        [Fact]
        public void ShouldNotCallRepositoryAndMapResult()
        {
            var now = DateTime.Now;
            var mockQueryRepo = A.Fake<IQueryRepository>();
            var mockMapper = A.Fake<IReportRowMapper>();
            A.CallTo(() => mockQueryRepo.GetDayResults(now)).Returns(Enumerable.Empty<JsonData>());

            IClassResultDataService classResultDataService = new ClassResultDataService(mockQueryRepo, mockMapper);

            classResultDataService.GetClassResult(now);

            A.CallTo(() => mockQueryRepo.GetDayResults(now)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => mockMapper.MapDataToReportRow(A<IEnumerable<JsonData>>._)).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
