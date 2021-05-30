namespace WorkResultsApi.Models
{
    public class ExerciseItem
    {
        public int ExerciseId { get; set; }
        public int Quantity { get; set; }
        public int correctAnswers { get; set; }        
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}