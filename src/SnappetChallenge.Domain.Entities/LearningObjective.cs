using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Entities
{
    public class LearningObjective : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Description { get; set; }
        public virtual Domain Domain { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
