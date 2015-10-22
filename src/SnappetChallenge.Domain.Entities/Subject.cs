using System.Collections.Generic;

namespace SnappetChallenge.Domain.Entities
{
    public class Subject : IEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Domain> Domains { get; set; }
    }
}