using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snappet.core.Models.ViewModels
{
    public class UserVM
    {
        public int UserID { get; set; }
        public List<LearningObjectiveVM> LearningObjectives { get; set; }

        public List<UserHistoryVM> UserHistory { get; set; }

        public List<UserLearningObjectDataItemVM> UserLearningObjData { get; set; } 
        
    }
}
