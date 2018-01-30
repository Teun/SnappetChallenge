namespace SnappetChallenge.Core.Models
{
    public class LearningObjective
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public double AverageProgress { get; set; }
        public UserForLearningObjective[] Users { get; set; }
    }
}