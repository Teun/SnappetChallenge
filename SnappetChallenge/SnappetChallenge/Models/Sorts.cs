using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
    public class Dropdowns
    {
        public IEnumerable<string> Domains { get; set; }
        public IEnumerable<int> ExerciseIds { get; set; }
        public IEnumerable<string> LearningObjectives { get; set; }
        public IEnumerable<string> Subjects { get; set; }
        public IEnumerable<int> Users { get; set; }
    }
}