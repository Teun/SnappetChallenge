namespace Service.Teachers.Models
{
    public class DashboardModel
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public int AnswerCount { get; set; }
        public string SubmitDateTime { get; set; }
    }
}
