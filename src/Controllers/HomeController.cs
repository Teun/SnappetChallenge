using Microsoft.AspNet.Mvc;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
