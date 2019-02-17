using System;

namespace Dashboard.Domain
{
    public class Answer
    {
        public int SubmittedAnswerId { get; set; }

        public DateTimeOffset SubmitDateTime { get; set; }

        public bool IsCorrect { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public float? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
