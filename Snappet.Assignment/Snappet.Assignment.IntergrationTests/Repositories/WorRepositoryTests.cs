using FluentAssertions;
using NUnit.Framework;
using Snappet.Assignment.Business.Interfaces;
using Snappet.Assignment.Business.UnitOfWork;
using Snappet.Assignment.Entities.DomainObjects;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Snappet.Assignment.IntergrationTests.Repositories
{
    [TestFixture]
    [Category(TestCategory.WorkRepository)]
    [Category(TestCategory.IntegrationTests)]
    public class WorRepositoryTests
    {
        private IUnitOfWork _uow;


        [SetUp]
        public void SetUp()
        {
            _uow = new UnitOfWork(GlobalSetUp.ConnectionString);

        }

        [TearDown]
        public void TearDown()
        {
            _uow = null;
        }

        [Test]
        public async Task Get_AllWorks_ShouldReturnListOfWork()
        {

            //Arrrange
            var expected = GlobalSetUp.Works;

            //Act
            var result = (await _uow.WorkRepository.GetAllAsync()).ToList();


            //Assert
            result.Should().HaveCount(c => c == expected.Count());


        }

        //Tuesday 2015-03-24 11:30:00 
        [TestCase(2015, 03, 24, 12, 00, 00)]
        [TestCase(2015, 03, 24, 11, 30, 00)]
        [TestCase(2015, 03, 24, 10, 30, 00)]
        [TestCase(2015, 03, 24, 10, 00, 00)]

        public async Task Get_TodayWorks_ShoulReturnOnlyTodayWork(short year, byte month, byte day, byte hour, byte minute, byte second)

        {
            //Arrange
            var today = new DateTime(year, month, day, hour, minute, second);

            Func<Work, bool> predicate = c => c.SubmitDateTime.Day == today.Day && c.SubmitDateTime.Hour <= today.Hour && c.SubmitDateTime.Minute <= today.Minute;
            Expression<Func<Work, bool>> expressionPredicate = c => c.SubmitDateTime.Day == today.Day && c.SubmitDateTime.Hour <= today.Hour && c.SubmitDateTime.Minute <= today.Minute;

            var expected = GlobalSetUp.Works.Where(predicate).ToList();

            //Act
            var result = (await _uow.WorkRepository.GetAllAsync(expressionPredicate)).ToList();

            //Assert

            result.Should().HaveCount(c => c == expected.Count());
        }

    }
}
