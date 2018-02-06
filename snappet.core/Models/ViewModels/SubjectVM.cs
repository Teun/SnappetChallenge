using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snappet.core.Models.ViewModels
{
    public class SubjectVM
    {
        public int SubjectID { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public List<LearningObjectiveVM> LearningObjectives { get; set; }
    }
}
