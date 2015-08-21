using System.Collections.Generic;

namespace SnappetChallenge.DAL.Entities
{
    public class Objective : BaseEntity
    {
        public string LearningObjective { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
