using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class Domain
    {    
        public string Name {get;set;}
        public IEnumerable<LearningObjective> LearningObjectives {get;set;}
    }
}
