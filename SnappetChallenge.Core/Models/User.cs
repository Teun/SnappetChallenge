namespace SnappetChallenge.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public LearningObjectiveForUser[] LearningObjectives { get; set; }
    }
}