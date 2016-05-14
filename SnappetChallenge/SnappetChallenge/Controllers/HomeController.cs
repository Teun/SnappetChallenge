using SnappetChallenge.Analysis;
using SnappetChallenge.Models;
using SnappetChallenge.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnappetChallenge.Global;

namespace SnappetChallenge.Controllers
{
	public class HomeController : Controller
	{ 
		private List<SubmittedAnswer> SubmittedAnswers
		{
			get
			{
				if (ControllerContext.HttpContext.Session["SubmittedAnswers"] == null)
					return null;
				return (List<SubmittedAnswer>)ControllerContext.HttpContext.Session["SubmittedAnswers"];
			}
			set
			{
				ControllerContext.HttpContext.Session["SubmittedAnswers"] = value;
			}
		}

		private SchoolClass SchoolClass
		{
			get
			{
				if (ControllerContext.HttpContext.Session["SchoolClass"] == null)
					return null;
				return (SchoolClass)ControllerContext.HttpContext.Session["SchoolClass"];
			}
			set
			{
				ControllerContext.HttpContext.Session["SchoolClass"] = value;
			}
		}

		public ActionResult Index()
		{
			//Load data for submitted answers into a session variable if the session is null. Keeping the data in memory
			//will make the application more efficient. The idea is that the data required for a particular class for a month
			//is a small subset of a much bigger set of data, and since we want to do a lot of different operations on the data
			//it will be much more efficient if it is memory as opposed to storing the data subset in a database. The session also
			//means we don't need to reload the data every time we want to refresh a page.
			if (this.SubmittedAnswers == null) {
				MockWorkWebservice mockWorkWebservice = new MockWorkWebservice();
				this.SubmittedAnswers = mockWorkWebservice.GetSubmittedAnswersForClass();
			}
			
			//Set time to 2015-03-24 11:30:00 UTC
			ViewBag.CurrentDateTime = new DateTime(2015, 3, 24, 11, 30, 0);

			WorkAnalysis workAnalysis = new WorkAnalysis(this.SubmittedAnswers);

			//Set up some mock data for the school class
			SchoolClass = new SchoolClass()
			{
				ClassId = 1,
				ClassName = "Groep 5a",
				TeacherName = "Dhr. Aldus Dumbledore",
				NumberOfStudents = workAnalysis.GetNumberOfStudents()
			};

			ViewBag.SchoolClass = SchoolClass;

			//Populate time period dropdown values
			List<SelectListItem> timePeriods = new List<SelectListItem>();
			timePeriods.Add(new SelectListItem { Text = "Vandaag", Value = Convert.ToString((int)TimePeriodEnum.Today) });
			timePeriods.Add(new SelectListItem { Text = "Laatste zeven dagen", Value = Convert.ToString((int)TimePeriodEnum.Week) });
			timePeriods.Add(new SelectListItem { Text = "Deze maand", Value = Convert.ToString((int)TimePeriodEnum.Month) });
			ViewBag.TimePeriods = timePeriods;

			return View();
		}

		public ActionResult About()
		{
			return View();
		}

	}
}