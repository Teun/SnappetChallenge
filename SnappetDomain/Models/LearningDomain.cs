using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetDomain.Models
{
    public class LearningDomain
    {
        public string Name { get; set; }
        public List<LearningObjectiveData> Objectives { get; set; }
    }
}
