using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class Subject
    {    
        public string Name {get;set;}
        public int ExercisesCount {get;set;}
        public int TotalProgress {get;set;}
        public double AverageDifficulty {get;set;}
        public IEnumerable<Exercise> Exercises {get;set;} = new List<Exercise>();
    }
}
