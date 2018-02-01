using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface ILearningObjectivesProvider
    {
        LearningObjective[] GetLearningObjectives(SubmittedAnswersFilter filter);
    }
}