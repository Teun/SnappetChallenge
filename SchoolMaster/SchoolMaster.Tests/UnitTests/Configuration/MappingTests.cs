using FluentAssertions;
using SchoolMaster.Models;
using SchoolMaster.Models.DataTransferObjects;
using SchoolMaster.Tests.Fixtures;
using Xunit;

namespace SchoolMaster.Tests.UnitTests.Configuration
{
    public class MappingTests : IClassFixture<AutoMapperFixture>
    {
        private readonly AutoMapperFixture _autoMapperFixture;

        public MappingTests(AutoMapperFixture fixture)
        {
            _autoMapperFixture = fixture;
        }

        [Fact]
        public void MappedMembers_ShouldBeValid()
        {
            // arrange
            var configuration = _autoMapperFixture.MapperConfiguration;

            // act
            var exception = Record.Exception(() => configuration.AssertConfigurationIsValid());

            // assert
            exception.Should().BeNull();
        }

        [Fact]
        public void MapUserToUserDto_WhenUserPassed_Should_Return_FullName_Correctly()
        {
            // arrange
            var user = new User
            {
                UserId = 22,
                Firstname = "Robin",
                LastName = "van Persie"
            };

            // act
            var userDto = _autoMapperFixture.Mapper.Map<UserDto>(user);

            // assert
            userDto.Should().NotBeNull();
            userDto.UserId.Should().Be(22);
            userDto.FullName.Should().Be("Robin van Persie");
        }
    }
}