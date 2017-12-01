using Snappet.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Web.Controllers
{
    public class HomeController : Controller
    {
        public const string DATE_FORMAT = "dd'/'MM'/'yyyy";

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDayResult(string dateText)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime date = DateTime.ParseExact(dateText, DATE_FORMAT, provider);

            var result = SimpleResolver.GetInstance<IStudentRecordsLogic>().GetRecords(date);

            return View("_Result", result);
        }

        [HttpPost]
        public ActionResult GetStudentProgressDetails(int studentID, string fromText, string toText)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime from = DateTime.ParseExact(fromText, DATE_FORMAT, provider);
            DateTime to = DateTime.ParseExact(toText, DATE_FORMAT, provider);

            //average progress per day
            //success rate per day
            List<double> daysProgress;
            List<double> daysSuccessRate;
            SimpleResolver.GetInstance<IStudentRecordsLogic>().GetProgressDetails(studentID, from, to, out daysProgress, out daysSuccessRate);

            return Json(new
            {
                daysProgress,
                daysSuccessRate
            });
        }
    }
}