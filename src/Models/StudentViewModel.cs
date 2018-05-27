using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models
{
    public class StudentViewModel
    {
        public DateTime Date { get; set; }
        public string LearningObjective { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
