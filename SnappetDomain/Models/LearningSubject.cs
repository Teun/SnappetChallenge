using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetDomain.Models
{
    public class LearningSubject
    {
        public string Name { get; set; }
        public List<LearningDomain> Domains { get; set; }
    }
}
