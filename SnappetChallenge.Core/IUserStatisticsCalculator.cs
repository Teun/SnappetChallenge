using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface IUserStatisticsCalculator
    {
        UserStatistics GetStatistics(User user);
    }
}