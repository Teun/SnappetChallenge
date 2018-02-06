using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Assignment.Entities.DomainObjects
{
    public class Work
    {
        public int SubmittedAnswerId { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public short Progress { get; set; }


        public double? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }

        public Exercise Exercise { get; set; }
       
        public User User { get; set; }

    }
}
