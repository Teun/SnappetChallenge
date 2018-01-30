using System.Linq;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public class LearningObjectiveStatisticsCalculator : ILearningObjectiveStatisticsCalculator
    {
        public LearningObectiveStatistics GetStatistics(LearningObjective learningObjective)
        {
            var usersProgress = learningObjective.Users
                .ToDictionary(u => u.UserId, u => u.UserAnswers.Sum(a => a.Progress));
            var learningObjectiveProgress = usersProgress.Values.Average();
            return new LearningObectiveStatistics(learningObjectiveProgress, usersProgress);
        }
    }
}