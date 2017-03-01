using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class Domain
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public ICollection<LearningObjective> LearningObjectives { get; set; }
    }
}