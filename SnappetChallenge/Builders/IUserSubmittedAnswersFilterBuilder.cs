using SnappetChallenge.Core.Models;
using SnappetChallenge.Models;

namespace SnappetChallenge.Builders
{
    public interface IUserSubmittedAnswersFilterBuilder
    {
        SubmittedAnswersFilter Build(DateRangeFilterDto dateRangeFilter, int userId);
    }
}