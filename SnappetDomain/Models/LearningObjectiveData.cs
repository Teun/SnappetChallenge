using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetDomain.Models
{
    public class LearningObjectiveData
    {
        public string Name { get; set; }
        public int NumberOfExercises { get; set; }
        public int NumberOfPupils { get; set; }
        public double AverageProgress { get; set; }
        public IEnumerable<LearningData> LearningData { get; set; }
    }
}
