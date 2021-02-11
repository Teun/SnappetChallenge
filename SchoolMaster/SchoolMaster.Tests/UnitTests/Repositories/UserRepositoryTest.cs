using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Repositories
{
    public class UserRepositoryTest : IClassFixture<RepositoryFixtures>
    {
        private readonly RepositoryFixtures _repositoryFixture;

        public UserRepositoryTest(RepositoryFixtures repositoryFixtures)
        {
            _repositoryFixture = repositoryFixtures;
        }

        [Fact]
        public async Task GetAllUsersAsync_Should_Return_Users()
        {
            // arrange
            var repo = _repositoryFixture.UserRepository;
            var userId = 40272;

            // act
            var users = await repo.GetAllUsersAsync();

            // assert
            users.Should().NotBeEmpty();
            users.First().UserId.Should().Be(userId);
        }
    }
}