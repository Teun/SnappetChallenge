using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Entities
{
    public class Domain : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Description { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<LearningObjective> LearningObjectives { get; set; }
    }
}
