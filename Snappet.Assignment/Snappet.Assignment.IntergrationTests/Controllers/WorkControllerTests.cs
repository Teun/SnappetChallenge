
using FluentAssertions;
using NUnit.Framework;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Business.UnitOfWork;
using Snappet.Assignment.Entities.DomainObjects;
using Snappet.Assignment.Entities.DTOs;
using Snappet.Assignment.Entities.Interfaces;
using Snappet.Assignment.Entities.Mapping;
using Snappet.Assignment.WebApp.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Assignment.IntergrationTests.Controllers
{
    [TestFixture]
    [Category(TestCategory.WorkController)]
    [Category(TestCategory.IntegrationTests)]
    public class WorkControllerTests
    {
        private WorkController _controller;
        private IUnitOfWork _uow;

        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _uow = new UnitOfWork(GlobalSetUp.ConnectionString);
            _mapper = new Mapper();
            _controller = new WorkController(_uow, _mapper);

        }
        [TearDown]
        public void TearDown()
        {
            _controller = null;
            _uow = null;
            _mapper = null;


        }
        [Test]
        public async Task Get_AllWorks_ShouldReturnListOfWorkDto()
        {
            //Arrange
            var expected = _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(GlobalSetUp.Works);

            //Act
            var result = await _controller.GetAll();


            //Assert         
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

            var data = GlobalSetUp.Works.Where(predicate).ToList();
            var expected = _mapper.Map<IEnumerable<Work>, IEnumerable<WorkDto>>(data);

            //Act
            var result = await _controller.GetToday();


            //Assert         
            result.Should().Equals(expected);
        }


    }
}
