using System;

namespace Snappet.Borisov.Test.Infrastructure
{
    public class SubmittedAnswerModel
    {
        public int SubmittedAnswerId { get; set; }
        public DateTimeOffset SubmitDateTime { get; set; }
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