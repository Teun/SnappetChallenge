using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Dal.Data;
using TutorBoard.Dal.Dtos;
using TutorBoard.Dal.Repositories;
using Xunit;

namespace TutorBoard.Dal.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private IEnumerable<WorkDto> _testData;

        public UserRepositoryTests()
        {
            _testData = new List<WorkDto>
            {
                new WorkDto {UserId = 1},
                new WorkDto {UserId = 2},
                new WorkDto {UserId = 3},
                new WorkDto {UserId = 2},
                new WorkDto {UserId = 1}
            };
        }
        
        [Fact]
        public async Task TestGetAsync()
        {
            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new UserRepository(contextMock.Object);

            // Act
            var result = await repository.GetAsync();

            // Verify
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task TestGetOneAsync()
        {
            const int userId = 1;

            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new UserRepository(contextMock.Object);

            // Act
            var result = await repository.GetOneAsync(userId);

            // Verify
            Assert.NotNull(result);
            Assert.Equal(userId, result.UserId);
        }

        [Fact]
        public async Task TestGetOneAsync_NotFound()
        {
            const int userId = 99;

            var contextMock = new Mock<IDataContext>();

            // Setup
            contextMock.Setup(c => c.GetWorkData()).Returns(_testData);

            var repository = new UserRepository(contextMock.Object);

            // Act
            var result = await repository.GetOneAsync(userId);

            // Verify
            Assert.Null(result);
        }
    }
}
