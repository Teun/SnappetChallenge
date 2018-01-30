using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Core.Builders;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Core.SubmittedAnswersQueryFilters;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core
{
    public class SubmittedAnswersProvider : ISubmittedAnswersProvider
    {
        private readonly ISubmittedAnswersRepository answersRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IEnumerable<ISubmittedAnswersQueryFilterHandler> filterHandlers;
        private readonly ISubmittedAnswerBuilder submittedAnswerBuilder;

        public SubmittedAnswersProvider(ISubmittedAnswersRepository answersRepository, 
            IUsersRepository usersRepository,
            IEnumerable<ISubmittedAnswersQueryFilterHandler> filterHandlers,
            ISubmittedAnswerBuilder submittedAnswerBuilder)
        {
            this.answersRepository = answersRepository;
            this.usersRepository = usersRepository;
            this.filterHandlers = filterHandlers;
            this.submittedAnswerBuilder = submittedAnswerBuilder;
        }

        public SubmittedAnswer[] GetAnswers(SubmittedAnswersFilter filter)
        {
            var answersQuery = ApplyFilter(answersRepository.Query(), filter);
            var usersQuery = usersRepository.Query();
            var answersWithUsers = answersQuery.Join(usersQuery, a => a.UserId, u => u.UserId, (a, u) => new
                {
                    Answer = a,
                    User = u
                })
                .ToArray();
            var result = answersWithUsers.Select(x => submittedAnswerBuilder.Build(x.Answer, x.User))
                .ToArray();
            return result;
        }

        private IQueryable<SubmittedAnswerDb> ApplyFilter(IQueryable<SubmittedAnswerDb> inputQuery, SubmittedAnswersFilter filter)
        {
            return filterHandlers.Aggregate(inputQuery, (current, filterHandler) => filterHandler.ApplyFilter(current, filter));
        }
    }
}