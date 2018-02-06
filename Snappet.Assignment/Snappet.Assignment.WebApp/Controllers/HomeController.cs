using Microsoft.AspNetCore.Mvc;

namespace Snappet.Assignment.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
