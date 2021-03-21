using FluentAssertions;
using LazyCache.Mocks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using SnappetChallenge.Repository.Config;
using SnappetChallenge.Repository.Interfaces;
using SnappetChallenge.Repository.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SnappetChallenge.Repository.Tests
{
    public class JsonRepositoryTests
    {
        [Fact]
        public async Task GivenThereIsNoCachedDataWhenCallingGetWorkResultsThenDataIsLoaded()
        {
            // Arrange
            var expectedWorkResults = new WorkResult[] { };

            var options = Options.Create(new RepositoryOptions {  JsonFilePath = $"mockFileThatDoesNotExist.json" });
            var fileLoaderMock = new Mock<IFileDataLoader>();

            fileLoaderMock
                .Setup(fileLoader => fileLoader.LoadFromFile<WorkResult, WorkResult[]>(options.Value.JsonFilePath))
                .Returns(Task.FromResult(expectedWorkResults));

            var repository = new JsonRepository(options, fileLoaderMock.Object, new MockCachingService());

            // Act
            var workResult = await repository.GetWorkResults();

            // Assert
            fileLoaderMock.VerifyAll();
            workResult.Should().NotBeNull();
            workResult.Should().BeSameAs(expectedWorkResults);
        }

        [Fact]
        public async Task GivenThereIsCachedDataWhenCallingGetWorkResultsThenDataIsNotLoaded()
        {
            // Arrange
            var expectedWorkResults = new WorkResult[] { };
            var cachingService = new LazyCache.CachingService();
            cachingService.Add("WorkResults", expectedWorkResults, new MemoryCacheEntryOptions());

            var options = Options.Create(new RepositoryOptions { JsonFilePath = $"mockFileThatDoesNotExist.json" });
            var fileLoaderMock = new Mock<IFileDataLoader>();

            var repository = new JsonRepository(options, fileLoaderMock.Object, cachingService);

            // Act
            var workResult = await repository.GetWorkResults();

            // Assert
            fileLoaderMock.Verify(fileLoaderMock => fileLoaderMock.LoadFromFile<WorkResult, WorkResult[]>(options.Value.JsonFilePath), Times.Never);
            workResult.Should().NotBeNull();
            workResult.Should().BeSameAs(expectedWorkResults);
        }
    }
}
