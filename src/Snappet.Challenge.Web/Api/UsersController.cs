using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Snappet.Challenge.Web.Api
{
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<User> Get()
        {
            return userService.GetAllUsers();
        }


        [HttpGet]
        public HttpResponseMessage GetProgressByUser(DateTime from, DateTime until)
        {
            var users = userService.GetProgressByUser(from, until);

            var returnValue = users.Select(kvp => new { Name = kvp.Key.Name, Progress = kvp.Value });
            
            // or return a dto here instead of anonymous type

            return Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }
    }
}