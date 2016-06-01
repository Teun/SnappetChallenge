using Snappet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        // instantiate the database class
        private SnappetDB db = new SnappetDB();

        /// <summary>
        /// instantiate the view for the index page
        /// if there is an id given as parameter the view will be loaded for that id
        /// </summary>
        /// <param name="id">the id of the user, if null then it is seen as all users</param>
        /// <returns>returns the View for the index page</returns>
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

        /// <summary>
        /// instantiate the view for the about page
        /// </summary>
        /// <returns>returns the View for the about page</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Application made by Niels Prasing";

            return View();
        }

        /// <summary>
        /// get the class and its information
        /// </summary>
        /// <returns>a class object with the information about the teacher and the students</returns>
        public Class GetClass()
        {
            Class returnClass = new Class("Mr. Potter");
            returnClass.Students = this.GetStudents();
            return returnClass;
        }

        /// <summary>
        /// get the students 
        /// </summary>
        /// <returns>a list of Users which are the students</returns>
        public List<User> GetStudents()
        {
            List<User> returnList = db.Users.OrderBy(u => u.Id).ToList();
            return returnList;
        }

        /// <summary>
        /// get the user for the given id
        /// </summary>
        /// <param name="id">the id of the user which we seek</param>
        /// <returns>a user or null when id is null</returns>
        public User GetUser(int? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}