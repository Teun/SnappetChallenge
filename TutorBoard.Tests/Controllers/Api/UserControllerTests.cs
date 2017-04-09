using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorBoard.Controllers.Api;
using TutorBoard.Dal.Models;
using TutorBoard.Dal.Repositories;
using Xunit;

namespace TutorBoard.Tests.Controllers.Api
{
    public class UserControllerTests
    {
        [Fact]
        public async Task TestGet()
        {
            IEnumerable<User> testUserData = new HashSet<User>
            {
                new User { UserId = 1, Name = "User 1"},
                new User { UserId = 2, Name = "User 2"},
                new User { UserId = 3, Name = "User 3"}
            };

            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            userRepositoryMock.Setup(c => c.GetAsync()).Returns(Task.FromResult(testUserData));

            var controller = new UserController(userRepositoryMock.Object);

            // Act
            var result = await controller.Get();

            // Verify
            userRepositoryMock.Verify(c => c.GetAsync(), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Same(testUserData, result);

        }

        [Fact]
        public async Task TestGetSingle()
        {
            const int userId = 1;
            var testUserData = new User { UserId = 1, Name = "User 1" };

            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            userRepositoryMock.Setup(c => c.GetOneAsync(userId)).Returns(Task.FromResult(testUserData));

            var controller = new UserController(userRepositoryMock.Object);

            // Act
            var result = await controller.Get(userId);

            // Verify
            userRepositoryMock.Verify(c => c.GetOneAsync(userId), Times.Once);

            Assert.NotNull(result);
            Assert.Same(testUserData, result);
        }

        [Fact]
        public async Task TestGetSingleNotFound()
        {
            const int userId = 1;

            var userRepositoryMock = new Mock<IUserRepository>();

            // Setup
            userRepositoryMock.Setup(c => c.GetOneAsync(userId)).Returns(Task.FromResult<User>(null));

            var controller = new UserController(userRepositoryMock.Object);

            // Act
            var result = await controller.Get(userId);

            // Verify
            userRepositoryMock.Verify(c => c.GetOneAsync(userId), Times.Once);

            Assert.Null(result);
        }
    }
}
