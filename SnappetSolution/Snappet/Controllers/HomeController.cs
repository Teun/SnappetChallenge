using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Snappet.Models;
using Snappet.Services;
using Snappet.Utilities;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkResultService service;

        public HomeController(IWorkResultService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetChartsData(DateTime currentDate)
        {
            var todaysResults = service.GetResults(currentDate.Date, currentDate);
            var yesterdaysResults = service.GetResults(currentDate.AddDays(-1).Date, currentDate.Date);

            var todaysCorrectnessData = todaysResults.GetCorrectnessByUserId("Today");
            var yesterdaysCorrectnessData = yesterdaysResults.GetCorrectnessByUserId("Yesterday");
            var correctnessDataList = new IList<GroupByItemOneAgg>[] { yesterdaysCorrectnessData, todaysCorrectnessData };

            return new JsonNetResult(new
            {
                SubjectChartData = todaysResults.GetCorrectnessBySub().PopulateChart(),
                DomainChartData = todaysResults.GetCorrectnessByDomain().PopulateChart(),
                CorrectnessCompChartData = correctnessDataList.PopulateChart()
            });
        }
    }
}