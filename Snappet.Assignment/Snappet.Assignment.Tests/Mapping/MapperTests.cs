using FluentAssertions;
using NUnit.Framework;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Entities.DTOs;
using Snappet.Assignment.Entities.Interfaces;
using Snappet.Assignment.Entities.Mapping;
using System.Linq;
namespace Snappet.Assignment.Tests.Mapping
{
    [TestFixture]
    [Category(TestCategory.UnitTest)]
    [Category(TestCategory.Mapper)]
    public class MapperTests
    {
        private IMapper _mapper;


        [SetUp]
        public void SetUp()
        {
            _mapper = new Mapper();

        }
        [TearDown]
        public void TearDown()
        {
            _mapper = null;

        }

        [Test]
        public void Map_UserDomainObjectToUserDto_ShouldReturnExacltlyTheSameObject()
        {
            //Arrange
            var expected = DummyData.Users.FirstOrDefault();

            //Act
            var result = _mapper.Map<User, UserDto>(expected);

            //Assert
            result.Id.Should().Be(expected.Id);
            result.Name.Should().Be(expected.Name);

        }


        [Test]
        public void Map_WorkDomainObjectToWorkDto_ShouldReturnExacltlyTheSameObject()
        {
            //Arrange
            var dd = DummyData.Works.ToList();
            var expected = DummyData.Works.FirstOrDefault();

            //Act
            var result = _mapper.Map<Work, WorkDto>(expected);

            //Assert
            result.SubmittedAnswerId.Should().Be(expected.SubmittedAnswerId);
            result.User.Name.Should().Be(expected.User.Name);
            result.Exercise.Name.Should().Be(expected.Exercise.Name);

        }



    }
}
