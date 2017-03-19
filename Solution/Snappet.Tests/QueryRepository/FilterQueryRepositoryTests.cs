using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Snappet.Data.DataObjects;
using Snappet.Data.QueryRepositories;
using Xunit;

namespace Snappet.Tests.QueryRepository
{
    public class FilterQueryRepositoryTests
    {
        readonly IQueryRepository _filterQueryRepository = new FilterQueryRepository(new JsonDataRepository(), "work.json");

        [Fact]
        public void ShouldGetRecordsBetweenLocalMidnightAndNow()
        {
            var utcNow = new DateTime(2015, 03, 02, 7, 37, 24, DateTimeKind.Utc).AddMilliseconds(030);

            IEnumerable<JsonData> data = _filterQueryRepository.GetDayResults(utcNow).ToList();

            data.Should().HaveCount(5);
            data.All(row => row.SubmitDateTime >= utcNow.Date).Should().BeTrue();
            data.All(row => row.SubmitDateTime <= utcNow).Should().BeTrue();

            // Verify edge case is included.
            data.FirstOrDefault(row => row.SubmitDateTime == utcNow.ToUniversalTime()).Should().NotBeNull();
        }

        [Fact]
        public void ShouldReturnEmptyCollectionWhenNoDataFound()
        {
            IEnumerable<JsonData> data = _filterQueryRepository.GetDayResults(new DateTime(2022, 2, 2, 1, 2, 3)).ToList();
            data.Should().HaveCount(0);
        }
    }
}
