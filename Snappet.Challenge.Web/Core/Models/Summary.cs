using System;
using System.Collections.Generic;

namespace Snappet.Challenge.Web.Core.Models
{
    public class Summary
    {
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public IList<Work> Questions { get; set; }
        public int Wrong { get; set; }
        public int Correct { get; set; }
        public int Total => Wrong + Correct;
        public int Ratio => Convert.ToInt32(Math.Round((Correct / (double) Total) * 100, 0));
        public string LearningObjective { get; set; }
    }
}