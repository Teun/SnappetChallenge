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
        private ClassworkClientService _clientService = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classworkClient"></param>
        public HomeController(IClassworkClientService classworkClient)
        {
            if (classworkClient.IsNullOrEmpty())
                throw new Exception(nameof(classworkClient));

            _clientService = (ClassworkClientService)classworkClient;
        }

        public async Task<IActionResult> Index(string activeTab = "todayTab")
        {
            var endDate = _currentDate;
            var startDate = _currentDate;

            switch (activeTab)
            {
                case "weekTab":
                    startDate = _currentDate.GetStartOfWeek();
                    break;
                case "monthTab":
                    startDate = _currentDate.GetStartOfMonth();
                    break;
                default:
                    startDate = _currentDate;
                    break;
            }
            


            var records = await _clientService.GetClassworkSummaryRecords(startDate, endDate);

            ViewData["ActiveTab"] = activeTab;
            return View(records);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
