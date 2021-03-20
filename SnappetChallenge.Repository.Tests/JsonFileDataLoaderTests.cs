using FluentAssertions;
using SnappetChallenge.Repository.DataLoader;
using SnappetChallenge.Repository.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SnappetChallenge.Repository.Tests
{
    public class JsonFileDataLoaderTests
    {
        [Fact]
        public async Task GivenARelativeFilePathWhenLoadFromFileThenItReturnsData()
        {
            // Arrange
            const int expectedRowCount = 37812;

            var fileLoader = new JsonFileDataLoader();

            // Act
            var workResult = await fileLoader.LoadFromFile<WorkResult, WorkResult[]>($"Data{Path.DirectorySeparatorChar}work.json");

            // Assert
            workResult.Should().NotBeNull();
            workResult.Should().HaveCount(expectedRowCount);
        }

        [Fact]
        public void GivenARelativeFilePathThatDoesNotExistWhenLoadFromFileThenItThrowsAFileNotFoundException()
        {
            // Arrange
            var fileLoader = new JsonFileDataLoader();

            // Act
            Func<Task<WorkResult[]>> act = async () => await fileLoader.LoadFromFile<WorkResult, WorkResult[]>($"DoesNotExist.json");

            // Assert
            act.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public async Task GivenSubmittedAnswer2593537IsInFileWhenLoadFromFileThenAnswerHasExpectedValues()
        {
            // Arrange
            var fileLoader = new JsonFileDataLoader();

            // Act
            var workResults = await fileLoader.LoadFromFile<WorkResult, WorkResult[]>($"Data{Path.DirectorySeparatorChar}work.json");
            var answer = workResults.SingleOrDefault(workResult => workResult.SubmittedAnswerId == 2593537);

            // Assert
            answer.Should().NotBeNull();
            answer.SubmitDateTime.Should().Be(new DateTime(2015, 3, 2, 8, 21, 47, 350));
            answer.Correct.Should().Be(1);
            answer.Progress.Should().Be(2);
            answer.UserId.Should().Be(40276);
            answer.ExerciseId.Should().Be(395184);
            answer.Difficulty.Should().Be("317.5509836");
            answer.Subject.Should().Be("Rekenen");
            answer.Domain.Should().Be("Getallen");
            answer.LearningObjective.Should().Be("Optellen en aftrekken tot �1000");
        }
    }
}
