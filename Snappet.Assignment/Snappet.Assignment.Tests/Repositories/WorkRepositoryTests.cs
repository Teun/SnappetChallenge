using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Business.Repositories;
using Snappet.Assignment.Data.Interfaces;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Tests.Extensions;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snappet.Assignment.Tests.Repositories
{
    [TestFixture]
    [Category(TestCategory.UnitTest)]
    [Category(TestCategory.WorkRepository)]
    public class WorkRepositoryTests
    {

        private IWorkRepository _repository;

        private Mock<ISchoolDbContext> _mockContext;

        private Mock<DbSet<Work>> _mockDbSet;



        [SetUp]
        public void SetUp()
        {

            _mockDbSet = new Mock<DbSet<Work>>();

            _mockContext = new Mock<ISchoolDbContext>();

            _repository = new WorkRepository(_mockContext.Object);

            _mockDbSet.SetSource(DummyData.Works.ToList());

            _mockContext.Setup(c => c.Works).Returns(_mockDbSet.Object);



        }
        [TearDown]
        public void TearDown()
        {
            _mockDbSet = null;

            _mockContext = null;

            _repository = null;


        }

        [Test]
        [Category(TestCategory.PositiveCases)]
        public async Task Get_AllWorks_ShouldReturnListOfWork()
        {
            //Arrange
            var expected = DummyData.Works;


            _mockContext.Setup(
            c => c.QueryAsync(
                It.IsAny<Expression<Func<Work, bool>>>(),
                It.IsAny<Expression<Func<Work, object>>[]>()))
                .ReturnsAsync(_mockDbSet.Object);

            //Act
            var result = (await _repository.GetAllAsync()).ToList();

            //Assert
            result.ShouldBeEquivalentTo(expected);

        }




        [TestCase(2015, 03, 24, 12, 00, 00)]
        [TestCase(2015, 03, 24, 11, 30, 00)]
        [TestCase(2015, 03, 24, 10, 30, 00)]
        [TestCase(2015, 03, 24, 10, 00, 00)]
        [Category(TestCategory.PositiveCases)]
        public async Task Get_AllWorksAtSpecificDateTime_ShouldReturnListOfOnlyWorksAtDateTime(short year, byte month, byte day, byte hour, byte minute, byte second)
        {
            //Arrange
            var today = new DateTime(year, month, day, hour, minute, second);

            var expected = DummyData.Works.Where(c => c.SubmitDateTime == today).ToList();




            Expression<Func<Work, bool>> predicate = s => s.SubmitDateTime == today;

            _mockContext.Setup(
            c => c.QueryAsync(
                It.IsAny<Expression<Func<Work, bool>>>(),
                It.IsAny<Expression<Func<Work, object>>[]>()))
                .ReturnsAsync(_mockDbSet.Object.Where(predicate));

            //Act
            var result = (await _repository.GetAllAsync()).ToList();

            //Assert
            result.ShouldBeEquivalentTo(expected);
        }

        [Test]
        [Category(TestCategory.NegativeCases)]
        public async Task Get_WorksAtFutureDate_ShouldReturn_0()
        {
            //Arrange
            var today = new DateTime().AddYears(1);

            var expected = DummyData.Works.Where(c => c.SubmitDateTime == today).ToList();



            Expression<Func<Work, bool>> predicate = s => s.SubmitDateTime == today;

            _mockContext.Setup(
            c => c.QueryAsync(
                It.IsAny<Expression<Func<Work, bool>>>(),
                It.IsAny<Expression<Func<Work, object>>[]>()))
                .ReturnsAsync(_mockDbSet.Object.Where(predicate));

            //Act
            var result = (await _repository.GetAllAsync()).ToList();

            //Assert
            result.ShouldBeEquivalentTo(expected);
            result.Count.Should().Be(0);


        }


    }
}
