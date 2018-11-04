using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Models;
using SnappedChallengeApi.UIServices.Implementations;
using SnappedChallengeApi.UIServices.Interfaces;

namespace SnappedChallengeApi.Controllers.UI
{
    public class HomeController : Controller
    {
        private DateTime _currentDate = DateTime.Parse("2015-03-24");
        private ClassworkClientService _client = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classworkClient"></param>
        public HomeController(IClassworkClientService classworkClient)
        {
            if (classworkClient.IsNullOrEmpty())
                throw new Exception(nameof(classworkClient));

            _client = (ClassworkClientService)classworkClient;
        }

        public async Task<IActionResult> Index()
        {
            var endDate = _currentDate;
            var startDate = _currentDate;
            //var record = await _client.GetClassworkSummary(startDate, endDate);

            ViewData["ActiveTab"] = "todayTab";
            return View();
        }

        public async Task<IActionResult> ThisWeek()
        {
            var endDate = _currentDate;
            var startDate = _currentDate.GetStartOfWeek();
            //var record = await _client.GetClassworkSummary(startDate, endDate);

            ViewData["ActiveTab"] = "weekTab";
            return View();
        }

        public async Task<IActionResult> ThisMonth()
        {
            var endDate = _currentDate;
            var startDate = _currentDate.GetStartOfMonth();

            //var record = await _client.GetClassworkSummary(startDate, endDate);

            ViewData["ActiveTab"] = "monthTab";
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
