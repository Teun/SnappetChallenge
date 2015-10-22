using Snappet.Challenge.Web.ViewModels;
using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Challenge.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            // Use something like AutoMapper here
            var users = userService.GetAllUsers();
            return View(users.Select(u => new UserViewModel {Name = u.Name }));
        }
    }
}