using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
	public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Import()
		{
			using(var db = new SnappetContext())
			{
				ViewBag.SubmittedAnswersCount = db.SubmittedAnswers.Count();
            }

			return View();
		}

		[HttpPost]
		public ActionResult Import(FormCollection collection)
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();

			List<string> messages = new List<string>();

			if (Request.Files == null || Request.Files.Count == 0)
			{
				return RedirectToAction("Index");
			}

			if (Request.Files[0] == null || Request.Files[0].ContentLength == 0)
			{
				return RedirectToAction("Index");
			}
			
			var serializer = new JsonSerializer();

			List<SubmittedAnswer> submittedAnswers;
			
			using (var file = new StreamReader(Request.Files[0].InputStream))
			{
				submittedAnswers = (List<SubmittedAnswer>)serializer.Deserialize(file, typeof(List<SubmittedAnswer>));
			}

			SubmittedAnswersImporter.Import(submittedAnswers);

			stopwatch.Stop();

			TempData["ImportResults"] = string.Format("{0} rijen geïmporteerd in {1:0.00} seconden", submittedAnswers.Count, stopwatch.Elapsed.TotalSeconds);

			return RedirectToAction("Import");
		}

		public ActionResult Clear()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();

			using (var db = new SnappetContext())
			{
				db.Database.ExecuteSqlCommand("TRUNCATE TABLE [SubmittedAnswers]");
			}

			sw.Stop();

			return RedirectToAction("Import");
		}
    }
}