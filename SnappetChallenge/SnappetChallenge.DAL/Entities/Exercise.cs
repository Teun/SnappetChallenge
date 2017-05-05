namespace SnappetChallenge.DAL.Entities
{
    using System.Collections.Generic;

    public class Exercise : BaseEntity
    {
        // foreign keys
        public long DomainId { get; set; }

        public long SubjectId { get; set; }

        public long ObjectiveId { get; set; }

        // ID in the original data. Because of the usage of an identity key we cannot set this value as a key but we store it for reference
        public long SourceId { get; set; }

        public double Difficulty { get; set; }

        //public string LearningObjective { get; set; }

        public virtual Domain Domain { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Objective Objective { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
