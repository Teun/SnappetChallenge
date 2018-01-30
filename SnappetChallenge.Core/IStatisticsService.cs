using System.Collections.Generic;
using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface IStatisticsService
    {
        double GetOverallProgress(IEnumerable<SubmittedAnswer> answers);
        double GetAverageProgress(IEnumerable<double> progresses);
    }
}