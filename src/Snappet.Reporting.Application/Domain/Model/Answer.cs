using System;

namespace Snappet.Reporting.Application.Domain.Model
{
    public class Answer
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public double Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
