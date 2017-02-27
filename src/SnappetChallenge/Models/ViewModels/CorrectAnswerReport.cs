using System;
using System.Collections.Generic;

namespace SnappetChallenge.Models.ViewModels
{
    public class CorrectAnswerReport
    {
        public int MaxAnsweredCount { get; set; }
        public IEnumerable<AnsweredDateResult> AnsweredDateResults { get; set; }
    }

    public class AnsweredDateResult
    {
        public DateTime AnsweredDate { get; set; }
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }
    }
}
