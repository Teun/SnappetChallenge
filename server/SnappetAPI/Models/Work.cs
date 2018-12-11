using System;

namespace SnappetAPI.Models
{
    public class Work
    {
        public int SubmittedAnswerId { get; set; }
        private string _submitDateTime;
        public string SubmitDateTime
        {
            get { return _submitDateTime; }
            set
            {
                _submitDateTime = value;
                try
                {
                    var date = Convert.ToDateTime(value);
                    SubmitDate = date.Date;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public DateTime SubmitDate { get; set; }


        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}