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
        private ClassworkClient _client = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classworkClient"></param>
        public HomeController(IClassworkClient classworkClient)
        {
            if (classworkClient.IsNullOrEmpty())
                throw new Exception(nameof(classworkClient));

            _client = (ClassworkClient)classworkClient;
        }

        public async Task<IActionResult> Index()
        {
            var endDate = DateTime.Parse("2015-03-24");
            var startDate = DateTime.Parse("2015-03-24");
            var record = await _client.GetClassworkSummary(startDate, endDate);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
