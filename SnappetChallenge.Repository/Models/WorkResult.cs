using System;

namespace SnappetChallenge.Repository.Models
{
    public class WorkResult
    {
        public long SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public short Correct { get; set; }
        public short Progress { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public string Difficulty { get; set; } // TODO: Figure out what the real data type is!
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}
