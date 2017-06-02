using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Data
{
    public class AssignmentProgress
    {
        public AssignmentProgress()
        {

        }

        public AssignmentProgress(int user, IEnumerable<Work> work)
        {
            UserId = user;
            CorrectAssignments = work.Count(w => w.Correct > 0);
            TotalAssignments = work.Count();
            IncorrectAssignments = TotalAssignments - CorrectAssignments;
        }

        public int UserId { get; set; }
        public int CorrectAssignments { get; set; }
        public int IncorrectAssignments { get; set; }
        public int TotalAssignments { get; set; }
    }
}
