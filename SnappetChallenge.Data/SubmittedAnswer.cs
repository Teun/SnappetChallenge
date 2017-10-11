using System;

namespace SnappetChallenge.Data
{
    public class SubmittedAnswer
    {
        public int Id { get; set; }

        public DateTime SubmittedDateTime { get; set; }

        public bool IsCorrect { get; set; }

        public int Progress { get; set; }

        public int UserId { get; set; }

        public int ExerciseId { get; set; }

        public double Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}