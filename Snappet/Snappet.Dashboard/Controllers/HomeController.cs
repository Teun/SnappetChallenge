using System.Web.Mvc;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}