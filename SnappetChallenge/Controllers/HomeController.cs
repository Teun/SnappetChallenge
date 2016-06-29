using SnappetChallenge.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        IJsonLoader jsonLoader;

        public HomeController(IJsonLoader jsonLoader)
        {
            this.jsonLoader = jsonLoader;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Report(string date)
        {
            DateTime parsedDate;
            if(!DateTime.TryParse(date, out parsedDate))
            {
                throw new ArgumentException("Incorrect date");
            }
            var work = getCachedWork();
            // Get all work from specified date, grouped by student id:
            var filtered = work.Where(x => x.SubmitDateTime.Date.Ticks == parsedDate.Date.Ticks)
                .GroupBy(y => y.UserId)
                .Select(z => new WorkResult(z.Key, z.ToList()));
            var jsonResult = Json(filtered);
            return jsonResult;
        }        

        private List<Answer> getCachedWork()
        {
            var cachedWork = (HttpContext.Cache["Work"] as List<Answer>);
            if (cachedWork == null)
            {
                cachedWork = jsonLoader.LoadJson(HttpContext.Server.MapPath("~/App_Data/work.json"));
                HttpContext.Cache.Insert("Work", cachedWork);
            }
            return cachedWork;
        }
    }
}