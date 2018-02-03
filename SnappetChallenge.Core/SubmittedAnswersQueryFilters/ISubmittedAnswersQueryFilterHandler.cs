using System.Linq;
using SnappetChallenge.Core.Models;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Core.SubmittedAnswersQueryFilters
{
    public interface ISubmittedAnswersQueryFilterHandler
    {
        IQueryable<SubmittedAnswerDb> ApplyFilter(IQueryable<SubmittedAnswerDb> input, SubmittedAnswersFilter filter);
    }
}