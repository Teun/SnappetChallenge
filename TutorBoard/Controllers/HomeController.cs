using System.Web.Mvc;
using TutorBoard.Dal.Providers;

namespace TutorBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTimeProvider _dateTime;

        public HomeController(IDateTimeProvider dateTime)
        {
            _dateTime = dateTime;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = string.Format("Overzicht {0:dd-MM-yyyy}", _dateTime.UtcNow);
            return View();
        }
    }
}