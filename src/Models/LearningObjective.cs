using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models
{
    public class LearningObjective
    {
        public string Title { get; set; }
        public string Domain { get; set; }
        public int TotalStudents { get; set; }
        public int TotalSubmittedAnswers { get; set; }
        public int TotalProgress { get; set; }
        public double AverageDifficulty { get; set; }
    }
}
