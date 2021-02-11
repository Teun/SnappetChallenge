using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using SchoolMaster.Services;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Services
{
    public class UserServiceTest : IClassFixture<RepositoryFixtures>, IClassFixture<AutoMapperFixture>
    {
        private readonly AutoMapperFixture _autoMapperFixture;
        private readonly RepositoryFixtures _repositoryFixture;

        public UserServiceTest(RepositoryFixtures repositoryFixtures, AutoMapperFixture autoMapperFixture)
        {
            _autoMapperFixture = autoMapperFixture;
            _repositoryFixture = repositoryFixtures;
        }

        [Fact]
        public async Task GetUsersAsync_Should_Return_Users()
        {
            // arrange
            var service = new UserService(_repositoryFixture.UserRepository, _autoMapperFixture.Mapper);

            // act
            var users = await service.GetAllUsersAsync();

            // assert
            users.Count.Should().Be(1);
            users.First().FullName.Should().Be("Robin van Persie");
        }
    }
}