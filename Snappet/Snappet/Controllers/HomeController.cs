using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snappet.Models.ViewModels;
using Snappet.Models.DataModels;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<AverageProgress> averages = DataSource.AverageProgress();

            ViewBag.Subjects = JsonConvert.SerializeObject(averages.Select(a => a.Subject.ToString()));
            ViewBag.Averages = JsonConvert.SerializeObject(averages.Select(a => a.Average));

            var model = new GraphModel();
            var todaysAnswers = DataSource.TodayResults();
            model.UserIds = todaysAnswers.Select(u => u.UserId).Distinct();

            if(Request.IsAjaxRequest())
            {
                var userId = Convert.ToInt32(Request.Form["DdlUserId"].ToString());
                var userAverage = todaysAnswers.Where(u => u.UserId == userId).GroupBy(g => g.Subject, p => p.Progress).Select(g => new AverageProgress
                {
                    Subject = g.Key,
                    Average = g.Average()
                });

                model.SubjectJson = JsonConvert.SerializeObject(userAverage.Select(ua => ua.Subject.ToString()));
                model.AveragesJson = JsonConvert.SerializeObject(userAverage.Select(ua => ua.Average));

                return PartialView("_UserProgress", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}