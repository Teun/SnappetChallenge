using System.Linq;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public class UserStatisticsCalculator : IUserStatisticsCalculator
    {
        public UserStatistics GetStatistics(User user)
        {
            var learningObjectivesProgress = user.LearningObjectives
                .ToDictionary(lo => new LearningObjectiveGroupValues(lo.Name, lo.Domain, lo.Subject),
                    lo => lo.Answers.Select(a => a.Progress).DefaultIfEmpty(0).Sum());
            var userProgress = learningObjectivesProgress.Values.DefaultIfEmpty(0).Average();
            return new UserStatistics(userProgress, learningObjectivesProgress);
        }
    }
}