using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Snappet.Data.DataObjects;
using Snappet.Data.Mappers;
using Xunit;

namespace Snappet.Tests.Mappers
{
    public class ReportRowMapperTests
    {
        private readonly IReportRowMapper _mapper = new ReportRowMapper();

        [Fact]
        public void ShouldGroupData()
        {
            var reportRows = _mapper.MapDataToReportRow(GetDataForUsers(1, 2, 3, 4, 5)).ToList();

            reportRows.Should().HaveCount(2);

            reportRows[0].Subject.Should().Be("xyz");
            reportRows[0].Count.Should().Be(5);
            reportRows[0].Correct.Should().Be(3);
            reportRows[0].Incorrect.Should().Be(2);
            reportRows[0].LearningObjective.Should().Be("Code quality");
            reportRows[0].PercentCorrect.Should().Be(60);
        }

        private IEnumerable<JsonData> GetDataForUsers(params int[] userIds)
        {
            return userIds.Select(userId => new JsonData()
            {
                Correct = userId % 2 != 0,
                LearningObjective = "Code quality",
                Subject = "xyz",
                UserId = userId
            })
            .Union(userIds.Select(userId => new JsonData()
            {
                Correct = userId % 2 == 0,
                LearningObjective = "Code quality",
                Subject = "abc",
                UserId = userId
            }));
        }
    }
}
