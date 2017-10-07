using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Challenge.Helpers
{
    public static class SinglePassStandardDeviationExtensions
    {
       
        public static double VarianceOfSample(this IEnumerable<double> source)
        {
            var count = source.Count();

            if (count <= 1) return 0;

            var mean = source.Average();
            var squaredDiffs = source.Select(d => (d - mean) * (d - mean));
            return squaredDiffs.Sum() / (count - 1);
        }
        public static double StdDevOfSample(this IEnumerable<double> source)
        {
            return Math.Sqrt(source.VarianceOfSample());
        }
    }
}