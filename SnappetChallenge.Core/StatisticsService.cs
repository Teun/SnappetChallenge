using System.Collections.Generic;
using System.Linq;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public class StatisticsService : IStatisticsService
    {
        public double GetOverallProgress(IEnumerable<SubmittedAnswer> answers)
        {
            return answers.Sum(a => a.Progress);
        }

        public double GetAverageProgress(IEnumerable<double> progresses)
        {
            return progresses.Average();
        }
    }
}