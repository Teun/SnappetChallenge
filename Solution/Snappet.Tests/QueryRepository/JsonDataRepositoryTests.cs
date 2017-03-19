using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Newtonsoft.Json;
using Snappet.Data.DataObjects;
using Snappet.Data.QueryRepositories;
using Xunit;

namespace Snappet.Tests.QueryRepository
{
    public class JsonDataRepositoryTests
    {
        private readonly List<JsonData> _data;
        private readonly IDataRepository _jsonDataRepository = new JsonDataRepository();

        public JsonDataRepositoryTests()
        {
            _data = _jsonDataRepository.GetDataFromJson("work.json").ToList();
        }

        [Fact]
        public void ShouldParseJsonAndReturnAllRows()
        {
            _data.Should().HaveCount(37812);
        }

        [Fact]
        public void ShouldParseAllFields()
        {
            var row = _data.First();

            row.SubmittedAnswerId.Should().Be(2395278);
            var dateTime = new DateTime(2015, 03, 02, 07, 35, 38, DateTimeKind.Utc).AddMilliseconds(740);
            row.SubmitDateTime.Should().Be(dateTime);
            row.Correct.Should().BeTrue();
            row.Progress.Should().Be(0);
            row.UserId.Should().Be(40281);
            row.ExerciseId.Should().Be(1038396);
            row.Difficulty.Should().Be("-200"); // TODO: Decimal/Float?
            row.Subject.Should().Be("Begrijpend Lezen");
            row.Domain.Should().Be("-");
            row.LearningObjective.Should().Be("Diverse leerdoelen Begrijpend Lezen");
        }

        [Fact]
        public void ShouldThrowExceptionWithFileNameFileNotFound()
        {
            Action action = () => _jsonDataRepository.GetDataFromJson("404.json").First();
                // If we don't enumerate there is no attempt to open the file...

            action.ShouldThrow<FileNotFoundException>().Where(ex => ex.Message.Contains("\\404.json"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenMissingMember()
        {
            Action action = () => _jsonDataRepository.GetDataFromJson("incorrectMember.json").ToList();

            action.ShouldThrow<JsonSerializationException>().Where(x => x.Message.Contains("Could not find member 'abc'"));
        }

        [Fact]
        public void ShouldThrowExceptionWhenDataIsInvald()
        {
            Action action = () => _jsonDataRepository.GetDataFromJson("incorrectData.json").ToList();

            action.ShouldThrow<JsonReaderException>()
                .WithMessage("Could not convert string to boolean: not a boolean. Path '[1].Correct', line 17, position 30.");
        }
    }
}
