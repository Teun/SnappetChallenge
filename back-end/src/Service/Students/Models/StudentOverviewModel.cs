namespace Service.Students.Models
{
    public class StudentOverviewModel
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public int AnswerCount { get; set; }
        public int Min { get; set; }
        public decimal Mean { get; set; }
        public int High { get; set; }
    }
}
