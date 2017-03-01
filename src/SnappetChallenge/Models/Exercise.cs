using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class Exercise
    {
        public string Id { get; set; }
        public double? Difficulty { get; set; }
        public LearningObjective LearningObjective { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}