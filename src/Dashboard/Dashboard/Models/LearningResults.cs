using System.Collections.Generic;

namespace Dashboard.Dashboard.Models
{
    public class LearningResults
    {
        public int ExerciseCount { get; set; }

        public float CorrectPercentage { get; set; }

        public IDictionary<string, LearningResults> Detalization { get; set; }
    }
}
