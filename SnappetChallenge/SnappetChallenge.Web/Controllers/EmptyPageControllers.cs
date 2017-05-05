using System.Collections.Generic;
using SnappetChallenge.Web.Models;

namespace SnappetChallenge.Web.Controllers
{
    using System.Web.Mvc;

    public class OverviewController : Controller
    {
        public ActionResult RawData()
        {
            return View();
        }

        public ActionResult Students()
        {
            return View();
        }

        public ActionResult Progress()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = new ListModel
            {
                ServerNames = new List<Server>
                {
                    new Server { Id = 1, Name = "Server1"},
                    new Server { Id = 2, Name = "Server2"},
                    new Server { Id = 3, Name = "Server3"},
                }
            };

            return View(model);

        }
    }
}