using ClassMonitor.Core.DomainAggregate;
using ClassMonitor.Core.LearningObjectiveAggregate;
using ClassMonitor.Core.SubjectAggregate;
using ClassMonitor.Core.UserAggregate;

namespace ClassMonitor.Core.WorkAggregate
{
    public class Work
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public double? Difficulty { get; set; }
        public int SubjectId { get; set; }
        public int DomainId { get; set; }
        public int LearningObjectiveId { get; set; }

        public User? User { get; set; }
        public Subject? Subject { get; set; }
        public Domain? Domain { get; set; }
        public LearningObjective? LearningObjective { get; set; }
    }
}
