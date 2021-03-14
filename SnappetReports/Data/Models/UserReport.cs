using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetReports.Data.Models
{
    public class UserReport
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public int AnswerCount { get; set; }
        public double MeanProgress { get; set; }
        public int MaxProgress { get; set; }
        public int MinProgress { get; set; }
    }
}
