using System;

namespace Snappet.Test.DataRecorder.Interface.Dtos
{
    public class ResultData
    {
        public int SubmittedAnswerId { get; set; }
        public DateTime SubmitDateTime { get; set; }
        public bool Correct { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public decimal? Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public int Progress { get; set; }
    }
}