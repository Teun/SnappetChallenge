using System.Collections.Generic;

namespace SnappetChallenge.Models
{
    public class Subject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Domain> Domains { get; set; }
    }
}
