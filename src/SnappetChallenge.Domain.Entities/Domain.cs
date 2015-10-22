using System.Collections.Generic;

namespace SnappetChallenge.Domain.Entities
{
    public class Domain : IEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<LearningObjective> LearningObjectives { get; set; }
    }
}