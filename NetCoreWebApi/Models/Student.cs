using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class Student
    {    
        public int Id {get;set;}
        public int ExercisesCount {get;set;}
        public int TotalProgress {get;set;}
        public double AverageDifficulty {get;set;}
        public IEnumerable<Subject> Subjects {get;set;} = new List<Subject>();
    }
}
