using System.Linq;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.SubmittedAnswersQueryFilters
{
    public class UserIdSubmittedAnswersQueryFilterHandler : ISubmittedAnswersQueryFilterHandler
    {
        public IQueryable<SubmittedAnswerDb> ApplyFilter(IQueryable<SubmittedAnswerDb> input, SubmittedAnswersFilter filter)
        {
            if (filter.UserId == null)
                return null;
            return input.Where(a => a.UserId == filter.UserId.Value);
        }
    }
}