using System;

namespace SnappetChallenge.Models
{
    public class SubmittedAnswerViewModel
    {
        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}