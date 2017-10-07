using Accord.Statistics.Distributions.Univariate;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.DataAnalytics
{
    public class DataAnalyticsFacade: IDataAnalyticsFacade
    {
        public IEnumerable<double> GenerateProbabilityDensitySample(IEnumerable<double> sampleData,double mean,double standardDeviation)
        {
            var normal = new NormalDistribution(mean: mean, stdDev: standardDeviation);
            var result = sampleData.Select(data =>
              {
                  return normal.ProbabilityDensityFunction(x: data);
  
              });
            return result;
        }
    }
}
