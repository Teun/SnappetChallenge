using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface ILearningObjectiveStatisticsCalculator
    {
        LearningObectiveStatistics GetStatistics(LearningObjective learningObjective);
    }
}