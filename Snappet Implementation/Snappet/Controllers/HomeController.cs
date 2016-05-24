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
        public ActionResult Index(int? id)
        {

            ViewBag.classClass = this.GetClass();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public List<UserClass> GetStudents()
        {
            List<UserClass> returnList = new List<UserClass>();
            returnList.Add(new UserClass(0L, "Student", "0"));
            returnList.Add(new UserClass(1L, "Student", "1"));
            returnList.Add(new UserClass(2L, "Student", "2"));
            returnList.Add(new UserClass(3L, "Student", "3"));
            returnList.Add(new UserClass(4L, "Student", "4"));
            returnList.Add(new UserClass(5L, "Student", "5"));
            return returnList;
        }

        public ClassClass GetClass()
        {
            ClassClass returnClass = new ClassClass("Mr. Potter");
            returnClass.Students = this.GetStudents();
            return returnClass;
        }
    }
}