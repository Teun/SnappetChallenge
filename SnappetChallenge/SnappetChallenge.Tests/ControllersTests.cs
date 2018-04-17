namespace SnappetChallenge.Tests
{
    using System;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SnappetChallenge.Core;
    using SnappetChallenge.Web.Controllers;
    using SnappetChallenge.Web.Models;
    using Xunit;

    public class ControllersTests
    {
        [Fact]
        public void TestHomeController()
        {
            var controller = new HomeController();
            var res = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(res);
            Assert.Null(viewResult.Model);

            var res2 = controller.Error();
            var viewResult2 = Assert.IsType<ViewResult>(res2);
            Assert.IsType<ErrorViewModel>(viewResult2.Model);
        }

        [Fact]
        public async Task TestReportController()
        {
            var options = new DbContextOptionsBuilder<ClassReportContext>()
                .UseInMemoryDatabase(databaseName: "TestReportController")
                .Options;

            using (var context = new ClassReportContext(options))
            {
                context.ReportItems.Add(new ReportItem { SubmitDateTime = DateTime.Now, Correct = 5 });
                context.SaveChanges();
            }

            using (var dbText = new ClassReportContext(options))
            {
                var controller = new ReportController(dbText);
                var res = await controller.GetReportItems(DateTime.Now);

                var viewResult = Assert.IsType<OkObjectResult>(res);
                var model = Assert.IsType<ApiResponse<ApiReportItem>>(viewResult.Value); ;
                Assert.Equal(model.Code, StatusCodes.Status200OK);
                Assert.Equal(1, model.ItemsCount);
                Assert.Equal(5, model.ReportItems[0].CorrectAnswers);
            }

        }
    }
}
