namespace SnappetChallenge.Core.Models
{
    public class LearningObjectiveForUser
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public SubmittedAnswer[] Answers { get; set; }
    }
}