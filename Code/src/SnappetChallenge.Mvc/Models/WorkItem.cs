using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Mvc.Models
{
    public class WorkItem
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as WorkItem;
            if (other == null)
                return false;

            return SubmittedAnswerId == other.SubmittedAnswerId && SubmitDateTime.Equals(other.SubmitDateTime) && Correct == other.Correct && Progress == other.Progress && UserId == other.UserId && ExerciseId == other.ExerciseId && string.Equals(Difficulty, other.Difficulty) && string.Equals(Subject, other.Subject) && string.Equals(Domain, other.Domain) && string.Equals(LearningObjective, other.LearningObjective);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = SubmittedAnswerId;
                hashCode = (hashCode * 397) ^ SubmitDateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Correct;
                hashCode = (hashCode * 397) ^ Progress;
                hashCode = (hashCode * 397) ^ UserId;
                hashCode = (hashCode * 397) ^ ExerciseId;
                hashCode = (hashCode * 397) ^ (Difficulty != null ? Difficulty.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Subject != null ? Subject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Domain != null ? Domain.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LearningObjective != null ? LearningObjective.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
