using System.Collections.Generic;
using System.Threading.Tasks;

using SnappetChallenge.Models;
using SnappetChallenge.Models.Contracts;

namespace SnappetChallenge.Services.Contracts
{
    public interface IClassResults
    {
        Task<int> GetAmountOfAnswersAsync(ITimeRange timeRange);
        Task<int> GetAmountCorrectAsync(ITimeRange timeRange);
        Task<int> GetTotalProgressAsync(ITimeRange timeRange);
        Task<User> GetMostProgressAsync(ITimeRange timeRange);
        Task<LearningObjective> GetMostDifficultAsync(ITimeRange timeRange);
        Task<IEnumerable<LearningObjective>> GetTopObjectivesAsync(ITimeRange timeRange);
    }
}
