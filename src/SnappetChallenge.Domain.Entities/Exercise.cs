using System.Collections.Generic;

namespace SnappetChallenge.Domain.Entities
{
    public class Exercise : IEntity
    {
        public long Id { get; set; }
        public long ExternalId { get; set; }
        public double Difficulty { get; set; }
        public virtual LearningObjective LearningObjective { get; set; }
        public virtual ICollection<SubmittedAnswer> SubmittedAnswers { get; set; }
    }
}