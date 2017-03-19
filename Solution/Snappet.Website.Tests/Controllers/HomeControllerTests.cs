using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FakeItEasy;
using FluentAssertions;
using Snappet.Data.DataObjects;
using Snappet.Data.DataServices;
using Snappet.Website.Controllers;
using Snappet.Website.Mappers;
using Xunit;

namespace Snappet.Website.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void ShouldCallDataServiceAndMapper()
        {
            var fakeDataService = A.Fake<IClassResultDataService>();
            var fakeTableMapper = A.Fake<ITableViewModelMapper>();

            var controller = new HomeController(fakeDataService, fakeTableMapper);
            controller.Index();

            A.CallTo(() => fakeDataService.GetClassResult(A<DateTime>._)).MustHaveHappened(Repeated.Exactly.Twice);
            A.CallTo(() => fakeTableMapper.CreateTableViewModel(A<string>._, A<IList<ClassResultRow>>._)).MustHaveHappened(Repeated.Exactly.Twice);

        }

        [Fact]
        public void ShouldNotThrowExceptionWhenDependencyDoes()
        {
            var fakeDataService = A.Fake<IClassResultDataService>();
            var fakeTableMapper = A.Fake<ITableViewModelMapper>();

            A.CallTo(() => fakeDataService.GetClassResult(A<DateTime>._)).Throws<Exception>();

            var controller = new HomeController(fakeDataService, fakeTableMapper);

            var actionResult = controller.Index();
            var view = ((ViewResult) actionResult).ViewName.Should().Be("Error");

            A.CallTo(() => fakeDataService.GetClassResult(A<DateTime>._)).MustHaveHappened(Repeated.Exactly.Once);
            A.CallTo(() => fakeTableMapper.CreateTableViewModel(A<string>._, A<List<ClassResultRow>>._)).MustHaveHappened(Repeated.Never);

        }
    }
}
