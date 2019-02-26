using System;

namespace SnappetTrueskill
{
    public class ExerciseInteraction
    {
        public int SubmittedAnswerId { get; }
        public DateTime SubmitDateTime { get; }
        public bool Correct { get; }
        public int Progress { get; }
        public int UserId { get; }
        public int ExerciseId { get; }
        public double Difficulty { get; }
        public string Subject { get; }
        public string Domain { get; }
        public string LearningObjective { get; }
    }
}
