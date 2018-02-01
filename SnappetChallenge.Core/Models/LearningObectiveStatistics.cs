using System;
using System.Collections.Generic;

namespace SnappetChallenge.Core.Models
{
    public class LearningObectiveStatistics
    {
        private readonly IDictionary<int, double> usersProgress;

        public LearningObectiveStatistics(double averageProgress, IDictionary<int, double> usersProgress)
        {
            this.AverageProgress = averageProgress;
            this.usersProgress = usersProgress;
        }

        public double AverageProgress { get; }

        public double GetUserProgress(int userId)
        {
            if (usersProgress.TryGetValue(userId, out double progress))
                return progress;
            throw new Exception($"Can't find statistics for user with id {userId}.");
        }
    }
}