namespace SnappetChallenge.Models
{
    public class LearningObjectiveForUserDto
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public double OverallProgress { get; set; }
        public AnswerForLearningObjectiveForUserDto[] Answers { get; set; }
    }
}