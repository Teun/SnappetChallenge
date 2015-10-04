using System.Globalization;

namespace Snappet.Domain.Contracts
{
    public class ExerciseResult
    {
        public int Id { get; set; }
        public int SubmittedAnswerId { get; set; }
        public System.DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public decimal? Difficulty { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public string LearningObjective { get; set; }
        public int DomainId { get; set; }
        public int SubjectId { get; set; }
        public int LearningObjectiveId { get; set; }
    }
}
