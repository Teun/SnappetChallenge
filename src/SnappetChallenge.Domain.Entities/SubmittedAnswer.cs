using System;

namespace SnappetChallenge.Domain.Entities
{
    public class SubmittedAnswer : IEntity
    {
        public long Id { get; set; }
        public DateTime SubmittedOn { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
        public virtual Exercise Exercise { get; set; }
        public virtual User SubmittedBy { get; set; }
    }
}