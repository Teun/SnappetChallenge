using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using SnappetChallenge.Mvc.Controllers.Api;
using SnappetChallenge.Mvc.DataLayer;
using SnappetChallenge.Mvc.Models;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace SnappetChallenge.Test
{
    public class WorkDataControllerUnitTests
    {
        [Fact]
        public async Task Values_Get_All()
        {
            // Arrange
            var cache = new MemoryCache(new MemoryCacheOptions());
            var workItemRepository = new Mock<IWorkItemRespository>();

            IList<WorkItem> expected = new List<WorkItem>
            {
                new WorkItem {
                    SubmittedAnswerId = 2395278,
                    SubmitDateTime = DateTime.Parse("2015-03-02T07:35:38.740"),
                    Correct = 1,
                    Progress = 0,
                    UserId = 40281,
                    ExerciseId = 1038396,
                    Difficulty = "-200",
                    Subject = "Begrijpend Lezen",
                    Domain = "-",
                    LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
                }
            };

            workItemRepository
                .Setup(s => s.GetAll(It.IsAny<Uri>()))
                .Returns(Task.FromResult(expected));

            var controller = new WorkItemController(cache, new FakeConfiguration(), workItemRepository.Object);

            // Act
            var result = (await controller.Get("http://google.com")).ToArray();

            // Assert
            result.Count().Should().Be(1);
            result[0].Should().Be(expected[0]);
        }

        public static IMemoryCache GetMemoryCache(object expectedValue)
        {
            var mockMemoryCache = new Mock<IMemoryCache>();
            mockMemoryCache
                .Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue))
                .Returns(true);
            return mockMemoryCache.Object;
        }

        class FakeConfiguration : IConfiguration
        {
            public IConfigurationSection GetSection(string key)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<IConfigurationSection> GetChildren()
            {
                throw new NotImplementedException();
            }

            public IChangeToken GetReloadToken()
            {
                throw new NotImplementedException();
            }

            public string this[string key]
            {
                get { return "1"; }
                set { throw new NotImplementedException(); }
            }
        }
    }

}
