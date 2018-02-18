using System.Collections.Generic;

namespace Snappet.Challenge.Models
{
    public class WorkQueryLists
    {
        public IEnumerable<string> Subjects { get; set; }
        public IEnumerable<string> Domains { get; set; }
        public IEnumerable<string> LearningObjectives { get; set; }
        public IEnumerable<int> Users { get; set; }
        public IEnumerable<int> Exercises { get; set; }
        public IEnumerable<bool> Correct { get; set; }
    }
}
