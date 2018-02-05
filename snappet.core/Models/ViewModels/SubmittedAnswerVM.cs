using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snappet.core.Models.ViewModels
{
    public class SubmittedAnswerVM
    {
        public int SubmittedAnswerID { get; set; }
        public int UserID { get; set; }
        public bool Correct { get; set; }
        public DateTime DateAnswered { get; set; }
        public int ExerciseID { get; set; }
        public int Progress { get; set; }
    }
}
