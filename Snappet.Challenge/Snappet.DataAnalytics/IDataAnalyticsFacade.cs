using System.Collections.Generic;

namespace Snappet.DataAnalytics
{
    public interface IDataAnalyticsFacade
    {
        IEnumerable<double> GenerateProbabilityDensitySample(IEnumerable<double> sampleData, double mean, double standardDeviation);
    }
}
