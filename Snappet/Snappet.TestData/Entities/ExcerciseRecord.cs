using System;

namespace Snappet.TestData.Entities
{
    internal class ExerciseRecord
    {
        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public bool IsCorrect => Correct == 1;
        public bool IsInCorrect => Correct == 0;
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}