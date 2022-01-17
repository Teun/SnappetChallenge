#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnappetChallenge.Data;
using SnappetChallenge.Models;
using SnappetChallenge.AggregateModels;

namespace SnappetChallenge.Controllers
{
    public class SummaryDataController : Controller
    {
        private readonly DataContext _context;

        private DateTime momentInTime = DateTime.Parse("2015-03-24 11:30:00");

        public SummaryDataController(DataContext context)
        {
            _context = context;
        }

        // GET: SummaryData
        public async Task<IActionResult> Index()
        {
            ViewData["MomentInTime"] = momentInTime;

            var summaryWorkView = _context.WorkDataModel
                .Where(x => x.SubmitDateTime < momentInTime)
                .GroupBy(y => new { y.SubmitDateTime.Date })
                .Select(g => new SummaryDataModel
                {
                    Date = g.Key.Date,
                    Correct0 = g.Count(i => (i.Correct == 0)),
                    Correct1 = g.Count(i => (i.Correct == 1)),
                    Correct3 = g.Count(i => (i.Correct == 3)),
                    ProgressLessThan0 = g.Count(i => (i.Progress < 0)),
                    ProgressOverThan0 = g.Count(i => (i.Progress > 0)),
                    AvgProgress = g.Where(ge => ge.Progress != 0).Average(a => a.Progress)
                }
                )
                .OrderBy(o => o.Date);

            return View(await summaryWorkView.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(DateTime momentInTime)
        {
            this.momentInTime = momentInTime;

            return await Index();

        }
    }
}
