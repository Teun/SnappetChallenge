using System.Linq;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.SubmittedAnswersQueryFilters
{
    public class ToSubmittedAnswersQueryFilterHandler : ISubmittedAnswersQueryFilterHandler
    {
        public IQueryable<SubmittedAnswerDb> ApplyFilter(IQueryable<SubmittedAnswerDb> input, SubmittedAnswersFilter filter)
        {
            if (filter.To == null)
                return input;
            return input.Where(a => a.SubmitDateTime < filter.To.Value);
        }
    }
}