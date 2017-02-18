using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class Domain
    {    
        public string Name {get;set;}
        public int TotalProgress {get;set;}
        public double AverageDifficulty {get;set;}

        public IEnumerable<LearningObjective> LearningObjectives {get;set;}
    }
}
