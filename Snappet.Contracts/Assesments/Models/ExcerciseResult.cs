using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.Models
{
    public class ExcerciseResult
    {
        public int SubmittedAnswerId { get; set; }
        public DateTimeOffset SubmitDateTime { get; set; }
        public byte Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
