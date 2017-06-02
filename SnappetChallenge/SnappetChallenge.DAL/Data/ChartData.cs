using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Data
{
    public class ChartData
    {
        public IEnumerable<string> Labels { get; set; }

        public Dictionary<string, IEnumerable<int>> DataSets { get; set; }
    }
}
