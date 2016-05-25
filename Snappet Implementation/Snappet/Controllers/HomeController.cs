using Snappet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        private SnappetDB db = new SnappetDB();
        private int? id;

        public ActionResult Index(int? id)
        {
            this.id = id;
            ViewBag.id = this.id;
            User user = db.Users.FirstOrDefault(u => u.Id == this.id);
            if (user != null)
            {
                ViewBag.name = user.Name;
            }
            else
            {
                ViewBag.name = null;
            }
            
            ViewBag.classClass = this.GetClass();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public Class GetClass()
        {
            Class returnClass = new Class("Mr. Potter");
            returnClass.Students = this.GetStudents();
            return returnClass;
        }

        public List<User> GetStudents()
        {
            List<User> returnList = db.Users.OrderBy(u => u.Id).ToList();
            return returnList;
        }
    }
}