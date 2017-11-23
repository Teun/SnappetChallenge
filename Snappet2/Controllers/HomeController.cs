using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet2.Models;
using Snappet2.ViewModel;

namespace Snappet2.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.SnappetContext _context;
        public HomeController(Data.SnappetContext context)
        {
            _context = context;
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

        public IActionResult Index(int? year, int? month, int? day)
        {
            DateTime date;
            if (!year.HasValue || !month.HasValue || !day.HasValue)
            {
                date = new DateTime(2015, 03, 24);
            }
            else
            {
                date = new DateTime(year.Value, month.Value, day.Value);
            }

            var homeViewModel = new HomeViewModel()
            {
                SubmittedAnswers = _context.SubmittedAnswers.Where(s => s.SubmitDateTime.Date == date).ToList(),
                ReportDateTime = date
            };
            return View(homeViewModel);
        }
    }
}
