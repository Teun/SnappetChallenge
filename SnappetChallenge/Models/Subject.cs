namespace SnappetChallenge.Models
{
    public class Subject
    {
        public string SubjectName { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public int TotalAnswered { get; set; }
        public int CorrectAnswered { get; set; }
    }
}