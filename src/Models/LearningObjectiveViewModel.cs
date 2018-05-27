using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models
{
    public class LearningObjectiveViewModel
    {
        public DateTime Date { get; set; }
        public IEnumerable<LearningObjective> Objectives { get; set; }
        public IEnumerable<ChartData<string, int>> Domains { get; set; }
    }
}
