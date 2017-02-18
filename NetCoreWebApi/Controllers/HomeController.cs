using System;
using Microsoft.AspNetCore.Mvc;

namespace SnappetWorkApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Date"] = new DateTime(2015,3,24);

            return View();
        }       
    }
}