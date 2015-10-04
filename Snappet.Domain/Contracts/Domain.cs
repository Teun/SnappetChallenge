using System.Collections.Generic;

namespace Snappet.Domain.Contracts
{
    public class Domain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
