using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.ClassInsights.Model.Dto
{
    public class DailySubmittedAnswersPerSubjectInsight
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public int CountOfSubmittedAnswers { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
    }
}
