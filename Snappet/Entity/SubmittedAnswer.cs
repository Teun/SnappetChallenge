using System;

namespace Snappet.Entity
{
    public class SubmittedAnswer
    {
        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public CorrectState Correct { get; set; }
        public ProgressState Progress { get; set; }
        public User User { get; set; }
        public Exercise Exercise { get; set; }
        public double? Difficulty { get; set; }
        public Subject Subject { get; set; }
        public Domain Domain { get; set; }
        public LearningObjective LearningObjective { get; set; }
    }
}