using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;

namespace SnappetChallenge.Core
{
    public class UsersProvider : IUsersProvider
    {
        private readonly ISubmittedAnswersProvider submittedAnswersProvider;
        private readonly IUsersRepository usersRepository;

        public UsersProvider(ISubmittedAnswersProvider submittedAnswersProvider, 
            IUsersRepository usersRepository)
        {
            this.submittedAnswersProvider = submittedAnswersProvider;
            this.usersRepository = usersRepository;
        }

        public User[] GetUsers(SubmittedAnswersFilter filter)
        {
            return IterateUsers(filter).ToArray();
        }

        private IEnumerable<User> IterateUsers(SubmittedAnswersFilter filter)
        {
            var answers = submittedAnswersProvider.GetAnswers(filter);
            var usersQuery = usersRepository.Query();
            if (filter.UserId != null)
                usersQuery = usersQuery.Where(u => u.UserId == filter.UserId.Value);
            var users = usersQuery // In real app there probably should be some filter by studying class
                .ToArray();
            var usersWithAnswers = users.GroupJoin(answers, u => u.UserId, a => a.User.UserId,
                (u, a) => new
                {
                    User = u,
                    Answers = a
                }).ToArray();
            foreach (var userWithAnswers in usersWithAnswers)
            {
                var learningObjectives = userWithAnswers.Answers
                    .GroupBy(a => new LearningObjectiveGroupValues(a.LearningObjective, a.Domain, a.Subject))
                    .Select(ag => new LearningObjectiveForUser
                    {
                        Name = ag.Key.Name,
                        Domain = ag.Key.Domain,
                        Subject = ag.Key.Subject,
                        Answers = ag.ToArray()
                    }).ToArray();
                var user = new User
                {
                    UserId = userWithAnswers.User.UserId,
                    Name = userWithAnswers.User.Name,
                    ImageId = userWithAnswers.User.ImageId,
                    LearningObjectives = learningObjectives
                };
                yield return user;
            }
        }
    }
}