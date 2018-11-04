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
    /// <summary>
    /// Web UI Single Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        //Now sistem time is 2015-03-24 11:30:00 and we should only represet data from this date and backwards.
        private DateTime _currentDate = DateTime.Parse("2015-03-24 11:30:00");
        /// <summary>
        /// Service instance
        /// </summary>
        private ClassworkClientService _clientService = null;

        /// <summary>
        /// Constructor with service injection
        /// </summary>
        /// <param name="classworkClient"></param>
        public HomeController(IClassworkClientService classworkClient)
        {
            if (classworkClient.IsNullOrEmpty())
                throw new Exception(nameof(classworkClient));

            _clientService = (ClassworkClientService)classworkClient;
        }

        /// <summary>
        ///  Single Page Controller Action that changes data but razor view
        /// </summary>
        /// <param name="activeTab"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string activeTab = "todayTab")
        {
            var endDate = _currentDate;
            var startDate = _currentDate;

            switch (activeTab)
            {
                case "weekTab":
                    startDate = _currentDate.GetStartOfWeek().Date;
                    ViewData["Title"] = "This Week";
                    break;
                case "monthTab":
                    startDate = _currentDate.GetStartOfMonth().Date;
                    ViewData["Title"] = "This Month";
                    break;
                default:
                    startDate = _currentDate.Date;
                    ViewData["Title"] = "Today";
                    break;
            }
            //in real application it should be a javascript function that makes http requests to backend restful service
            //being a little tired i binded data from controller but also with rest endpoint clients
            var records = await _clientService.GetClassworkSummaryRecords(startDate, endDate);
            var lineGraphData = _clientService.SummarizeClassworkRecordsByDate(records);

            ViewData["CurrentDate"] = _currentDate.ToString("dd.MM.yyyy HH:mm");
            ViewData["ActiveTab"] = activeTab;
            ViewData["GraphSeries"] = string.Format("[{0}]", string.Join(',', lineGraphData.Select(f => string.Format("'{0}'", f.Date.ToString("dd.MM.yyyy")))));
            ViewData["GraphValues"] = string.Format("[{0}]", string.Join(',', lineGraphData.Select(f => f.TotalProgress)));
            return View(records);
        }

        /// <summary>
        /// Error Page controller
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
