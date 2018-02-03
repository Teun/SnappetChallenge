using System.Linq;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public class LearningObjectiveStatisticsCalculator : ILearningObjectiveStatisticsCalculator
    {
        public LearningObectiveStatistics GetStatistics(LearningObjective learningObjective)
        {
            var usersProgress = learningObjective.Users
                .ToDictionary(u => u.UserId, u => u.UserAnswers
                    .Select(a => a.Progress).DefaultIfEmpty(0).Sum());
            var learningObjectiveProgress = usersProgress.Values.DefaultIfEmpty(0).Average();
            return new LearningObectiveStatistics(learningObjectiveProgress, usersProgress);
        }
    }
}