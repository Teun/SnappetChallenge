namespace backend.Repository
{
    [System.Serializable]
    public class Student
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string ClassDomain { get; set; }
        public string LearningObjective { get; set; }
        public int TotalExercises { get; set; }
        public int Correct { get; set; }
        public int Wrong { get; set; }
        public decimal Accuracy { get; set; }

    }
}