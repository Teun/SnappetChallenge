namespace SnappetChallenge.Models
{
    public class LearningObjectiveDto
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public double AverageProgress { get; set; }
        public UserForLearningObjectiveDto[] Users { get; set; }
    }
}
    