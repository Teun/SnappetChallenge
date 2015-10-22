using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Entities
{
    public class Subject : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Domain> Domains { get; set; }
    }
}
