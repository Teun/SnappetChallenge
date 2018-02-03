namespace SnappetChallenge.Core.Models
{
    public class UserForLearningObjective
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public SubmittedAnswer[] UserAnswers { get; set; }
    }
}