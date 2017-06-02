using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Data
{
    public class SubjectProgress
    {
        public SubjectProgress()
        {

        }

        public SubjectProgress(string subject, IEnumerable<Work> work)
        {
            Subject = subject;
            TotalAssignments = work.Count();
            CorrectAssignments = work.Count(w => w.Correct > 0);
            IncorrectAssignments = TotalAssignments - CorrectAssignments;
        }

        public string Subject { get; set; }
        public int TotalAssignments { get; set; }
        public int CorrectAssignments { get; set; }
        public int IncorrectAssignments { get; set; }
    }
}
