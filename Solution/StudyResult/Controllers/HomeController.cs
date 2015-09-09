using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyReport.DataAccess;
using StudyReport.Entities;
using StudyReport.Models;
using Newtonsoft.Json;

namespace StudyReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Load data
            StudyReportContext ctx = new StudyReportContext();
            ctx.Database.Initialize(true);

            var answerVms = new AnswerViewModel().ListAnswerViewModel();
            return View(answerVms);
        }

        [HttpPost]
        public ViewResult Index(bool hideZeroProgress, bool hideNullDifficulty)
        {
            var answerVms = new AnswerViewModel()
                .ListAnswerViewModel()
                .Where(
                    x => (!hideZeroProgress || x.Progress != 0)
                        && (!hideNullDifficulty || x.Difficulty.HasValue))
                .ToList();
            return View(answerVms);
        }

        public ActionResult Chart()
        {

            return View();
        }

        public ContentResult GetData()
        {
            var answerVms = new AnswerViewModel().ListAnswerViewModel();

            var result = answerVms
                .GroupBy(x => x.LearningObjective)
                .Select(x => 
                    new { 
                        LearningObjective = x.Key,
                        Progress = x.Sum(y => y.Progress) 
                    })
                .Distinct()
                .OrderBy(x => x.LearningObjective)
                .ToList();

            return Content(JsonConvert.SerializeObject(result), "application/json");
        }

    }
}