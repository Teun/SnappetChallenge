namespace SnappetChallenge.Models
{
    public class UserDetailsDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public double AverageProgress { get; set; }
        public LearningObjectiveForUserDto[] LearningObjectives { get; set; }
    }
}