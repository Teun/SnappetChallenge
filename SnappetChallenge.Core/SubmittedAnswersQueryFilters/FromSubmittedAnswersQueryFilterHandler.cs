using System.Linq;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.SubmittedAnswersQueryFilters
{
    public class FromSubmittedAnswersQueryFilterHandler : ISubmittedAnswersQueryFilterHandler
    {
        public IQueryable<SubmittedAnswerDb> ApplyFilter(IQueryable<SubmittedAnswerDb> input, SubmittedAnswersFilter filter)
        {
            if (filter.From == null)
                return input;
            return input.Where(a => a.SubmitDateTime >= filter.From.Value);
        }
    }
}