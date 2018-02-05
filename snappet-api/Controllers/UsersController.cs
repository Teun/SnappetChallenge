using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using snappet.core.Contracts;
using snappet.core.Implementation;
using snappet.core.Models.EF;
using snappet.core.Models.ViewModels;

namespace snappet_api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserMethods _userMethods;

        public UsersController()
        {
            _userMethods = new UserMethods();
        }

        [HttpGet]
        public List<UserVM> GetAllUsers()
        {
            return _userMethods.GetAllUsers();
        }

        [HttpGet]
        public UserVM GetSpecificUser(int UserID, int Weeks = 1)
        {
            return _userMethods.GetSpecificUser(UserID, Weeks);
        }

       

    }
}
