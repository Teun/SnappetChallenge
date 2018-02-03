using System;
using System.Collections.Generic;

namespace SnappetChallenge.Core.Models
{
    public class UserStatistics
    {
        private readonly IDictionary<LearningObjectiveGroupValues, double> learningObjectivesProgress;
        public double AverageProgress { get; }

        public UserStatistics(double averageProgress, IDictionary<LearningObjectiveGroupValues, double> learningObjectivesProgress)
        {
            this.learningObjectivesProgress = learningObjectivesProgress;
            AverageProgress = averageProgress;
        }

        public double GetLearningObjectiveProgress(string name, string domain, string subject)
        {
            if (learningObjectivesProgress.TryGetValue(new LearningObjectiveGroupValues(name, domain, subject),
                out double result))
            {
                return result;
            }
            throw new Exception($"Can't find statistics for learning objective {name} | {domain} | {subject}.");
        }
    }
}