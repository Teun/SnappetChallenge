using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    using ChartJSCore.Models;

    using SnappetChallenge.Models.Interfaces;

    public class HomeController : Controller
    {
        private IDataRepository _dataRepository;

        public HomeController(IDataRepository dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        public IActionResult Index()
        {
            List<ClassAssignment> assignments = this._dataRepository.GetClassAssignments();

            var chart = new ChartData().PrepareChartWithData(assignments);

            ViewData["DateFilterData"] = ChartData.DateFilterItems;
            ViewData["chart"] = chart.Chart;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string dateFilter)
        {
            if ((dateFilter ?? string.Empty) == string.Empty)
                return RedirectToAction("Index");
            if (!DateTime.TryParse(dateFilter, out DateTime inputDateTime))
                return new BadRequestResult();
            var assignments = this._dataRepository.GetClassAssignmentsByDate(inputDateTime);
            var chart = new ChartData().PrepareChartWithData(assignments, true);
            ChartData.DateFilterItems.First(x => x.Value == dateFilter).Selected = true;
            ViewData["DateFilterData"] = ChartData.DateFilterItems;
            ViewData["chart"] = chart.Chart;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
