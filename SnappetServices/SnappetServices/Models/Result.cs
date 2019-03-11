using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Models
{
    public class Result
    {
        public int SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public int Correct { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public string Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
