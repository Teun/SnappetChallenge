using System.Collections;
using System.Collections.Generic;

namespace SnappetChallenge.DAL.Entities
{
    public class Domain : BaseEntity
    {
        public string DomainName { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
