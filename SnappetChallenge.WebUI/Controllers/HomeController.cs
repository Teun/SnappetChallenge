using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.WebUI.Models;

namespace SnappetChallenge.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.ViewData["Message"] = "Students result";

            return View();
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}
    }
}
