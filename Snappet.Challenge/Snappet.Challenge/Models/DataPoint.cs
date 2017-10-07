using System.Collections.Generic;

namespace Snappet.Challenge.Models
{
    public class DataPoint
    {
        public IEnumerable<double> Data { get; set; }
        public IEnumerable<double> Distribution { get; set; }

        public DataPoint()
        {
            Data = new List<double>();
            Distribution = new List<double>();
        }
    }
}