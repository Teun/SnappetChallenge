using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class LearningObjective
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Domain Domain { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}