using SnappetChallenge.Domain.Contracts;
using SnappetChallenge.Domain.Entities;
using SnappetChallenge.Services.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SnappetChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly ISnappetChallengeContext context;

        public UserService(ISnappetChallengeContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.GetRepository<User>().GetAll().ToList();
        }

        public int GetUserCount()
        {
            var users = context.GetRepository<User>().GetAll();

            return users.Count();
        }
    }
}