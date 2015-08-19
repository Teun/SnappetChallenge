namespace SnappetChallenge.DAL.Entities
{
    using System;
    
    public class StudentAnswer : BaseEntity
    {
        public long SubmittedAnswerId { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public bool Correct { get; set; }

        public int Progress { get; set; }

        public long UserId { get; set; }

        public long ExerciseId { get; set; }

        public double? Difficulty { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string LearningObjective { get; set; }
    }
}
