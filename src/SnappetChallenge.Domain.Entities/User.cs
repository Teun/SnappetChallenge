using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Domain.Entities
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }
        public virtual long ExternalId { get; set; }
        public virtual string Name { get; set; }
    }
}
