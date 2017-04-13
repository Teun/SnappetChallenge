// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ReportController.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------
namespace Demo.Report.API.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class ReportController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public ReportController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("api/report")]
        public object Get()
        {
            DateTime today = new DateTime(2015, 3, 24);
            var fileInfo = hostingEnvironment.ContentRootFileProvider.GetFileInfo("data/work.json");
            var items = new WorkDataRepository(fileInfo.PhysicalPath).LoadAll().Where(x => x.SubmitDateTime.Date >= today.Date).ToList();

            var reportProvider = new ReportProvider(items);
            var reportModel = reportProvider.PrepareClassOverviewReport(today);
            return reportModel;
        }

        public IActionResult Index()
        {
            DateTime today = new DateTime(2015, 3, 24);
            var fileInfo = hostingEnvironment.ContentRootFileProvider.GetFileInfo("data/work.json");
            var items = new WorkDataRepository(fileInfo.PhysicalPath).LoadAll().Where(x => x.SubmitDateTime.Date >= today.Date).ToList();

            var reportProvider = new ReportProvider(items);
            var reportModel = reportProvider.PrepareClassOverviewReport(today);
            return View(reportModel);
        }
    }
}