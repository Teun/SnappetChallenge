using System;

namespace Snappet.Reporting.Model
{
    public class WorkStatisticsByTopic
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        public int TotalAnswers { get; set; }
        public int TotalProgress { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalExercises { get; set; }
        public double AverageDifficulty { get; set; }
    }

}