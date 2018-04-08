using System;

namespace Snappet.Challenge.Web.Core.ViewModel
{
    public class LearningObjectiveSummaryViewModel
    {
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public string LearningObjective { get; set; }

        public int StudentRatio => Convert.ToInt32(Math.Round((StudentCorrectAnswer / (double) StudentTotalAnswer) * 100, 0));
        public int StudentCorrectAnswer { get; set; }
        public int StudentTotalAnswer { get; set; }

//        public int ClassRatio => Convert.ToInt32(Math.Round((ClassCorrectAnswer / (double) ClassTotalAnswer) * 100, 0));
//        public int ClassCorrectAnswer { get; set; }
//        public int ClassTotalAnswer { get; set; }
    }
}