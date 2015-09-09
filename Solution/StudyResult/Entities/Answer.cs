using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyReport.Entities
{
    public class Answer : BaseEntity
    {
        public int AnswerId { get; set; }
        public DateTime? SubmitDateTime { get; set; }
        public AnswerCorrect Correct { get; set; }
        public virtual User User { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int Progress { get; set; }
    }

    public enum AnswerCorrect
    {
        Incorrect = 0,
        Corrct = 1,
        Unknown = 3 // No answer given, skip, or time out?
    }
}
