using System.Collections.Generic;

namespace SnappetChallenge.Domain.Entities
{
    public class LearningObjective : IEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}