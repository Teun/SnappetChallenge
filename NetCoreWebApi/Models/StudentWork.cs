using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class StudentWork
    {    
        public int StudentId {get;set;}
        public IEnumerable<Subject> Subjects {get;set;}
    }
}
