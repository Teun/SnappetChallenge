using System.Collections.Generic;

namespace SnappetWorkApp.Models
{
    public class Subject
    {    
        public string Name {get;set;}
        public IEnumerable<Domain> Domains {get;set;}
    }
}
