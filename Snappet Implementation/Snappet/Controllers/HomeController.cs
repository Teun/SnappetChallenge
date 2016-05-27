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

        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            User user = this.GetUser(id);
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

        public User GetUser(int? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}