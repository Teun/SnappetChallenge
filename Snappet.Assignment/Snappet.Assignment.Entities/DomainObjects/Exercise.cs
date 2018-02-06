using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Assignment.Entities.DomainObjects
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Work> Works { get; set; }
    }
}
