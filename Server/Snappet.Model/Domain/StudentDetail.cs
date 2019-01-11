using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Model.Domain
{
    public class StudentDetail
    {
        public int UserId { get; set; }

        public int TotalAttempts { get; set; }

        public int TotalAttemptsWrong { get; set; }

        public int TotalAttemptsRight { get; set; }

        public int Progress { get; set; }
        public int TotalExercise { get; set; }
    }
}
