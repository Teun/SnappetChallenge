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

        public Dictionary<User, int> GetProgressByUser(DateTime from, DateTime until)
        {
            var allAnswers = context.GetRepository<SubmittedAnswer>().GetAll();

            var dictionary =
                (
                    from answer in allAnswers
                    where answer.SubmittedOn >= @from && answer.SubmittedOn <= until
                    group answer by answer.SubmittedBy
                    into grp
                    select new
                    {
                        User = grp.Key,
                        Progress = grp.Sum(a => a.Progress)
                    }
                )
                .OrderBy(u => u.Progress)
                .ToDictionary(result => result.User, result => result.Progress);

            return dictionary;
        }

        public int GetUserCount()
        {
            var users = context.GetRepository<User>().GetAll();

            return users.Count();
        }
    }
}