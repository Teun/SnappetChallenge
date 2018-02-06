using FluentAssertions;
using Moq;
using NUnit.Framework;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Entities.DTOs;
using Snappet.Assignment.Entities.Interfaces;
using Snappet.Assignment.Entities.Mapping;
using Snappet.Assignment.WebApp.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snappet.Assignment.Tests.Controllers
{
    [TestFixture]
    [Category(TestCategory.UnitTest)]
    [Category(TestCategory.WorkController)]
    public class WorkControllerTests
    {
        private WorkController _controller;
        private Mock<IUnitOfWork> _mockUow;
        private Mock<IWorkRepository> _mockRepository;

        private IMapper _mapper;
        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IWorkRepository>();

            _mockUow = new Mock<IUnitOfWork>();

            _mockUow.Setup(c => c.WorkRepository).Returns(_mockRepository.Object);

            _mapper = new Mapper();

            _controller = new WorkController(_mockUow.Object, _mapper);

        }
        [TearDown]
        public void TearDown()
        {
            _controller = null;
            _mockUow = null;
            _mockRepository = null;
            _mapper = null;
        }

        [Test]
        public async Task Get_AllWorks_ShouldReturnListOfWorkDto()
        {
            //Arrange
            var expected = _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(DummyData.Works.ToList());
            _mockRepository.Setup(
               c => c.GetAllAsync(
                   It.IsAny<Expression<Func<Work, bool>>>(),
                   It.IsAny<Expression<Func<Work, object>>[]>()))
                   .ReturnsAsync(DummyData.Works.AsQueryable);


            //Act
            var result = await _controller.GetAll();


            //Assert   
            result.Count().Should().Be(expected.Count());
            result.Should().Equals(expected);
        }

        [Test]
        public async Task Get_AllWorksAtSepicificDateTime_ShouldReturnListOfWorkDtoAtOrBeforeThisDateTime()
        {
            //Arrange
            var today = new DateTime(2015, 03, 24, 11, 30, 00);

            Func<Work, bool> predicate = c => c.SubmitDateTime.Day == today.Day &&
                                              c.SubmitDateTime.Hour <= today.Hour &&
                                              c.SubmitDateTime.Minute <= today.Minute;

            var expected = DummyData.Works.Where(predicate).ToList();

            _mockRepository.Setup(
               c => c.GetAllAsync(
                   It.IsAny<Expression<Func<Work, bool>>>(),
                   It.IsAny<Expression<Func<Work, object>>[]>()))
                   .ReturnsAsync(expected.AsQueryable);


            //Act
            var result = await _controller.GetToday();


            //Assert         
            result.Count().Should().Be(expected.Count());
            result.Should().Equals(expected);
        }

    }
}
