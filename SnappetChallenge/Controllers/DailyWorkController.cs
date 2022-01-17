#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SnappetChallenge.AggregateModels;
using SnappetChallenge.Data;
using SnappetChallenge.Models;


namespace SnappetChallenge.Controllers
{
    public class DailyWorkController : Controller
    {
        private readonly DataContext _context;

        private DateTime momentInTime = DateTime.Parse("2015-03-24 11:30:00");

        public DailyWorkController(DataContext context)
        {
            _context = context;
        }

        // GET: DailyWorkToTheMoment
        public async Task<IActionResult> Index()
        {
            ViewData["MomentInTime"] = momentInTime;

            var dailyWorkView = _context.WorkDataModel
                .Where(x => x.SubmitDateTime < momentInTime && x.SubmitDateTime > momentInTime.Date)
                .GroupBy(y => new { y.LearningObjective, y.Domain, y.Subject })
                .Select(g => new DailyWorkModel
                 {
                    LearningObjective = g.Key.LearningObjective,
                    Domain = g.Key.Domain,
                    Subject = g.Key.Subject,
                    Correct0 = g.Count(i => (i.Correct == 0)),
                    Correct1 = g.Count(i => (i.Correct == 1)),
                    Correct3 = g.Count(i => (i.Correct == 3)),
                    AvgProgress = g.Where(ge => ge.Progress != 0).Average(a => a.Progress)
                });
           
            return View(await dailyWorkView.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Index(DateTime momentInTime)
        {
            this.momentInTime = momentInTime;

            return await Index();

        }



    }
}
