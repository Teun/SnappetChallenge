using System.Collections.Generic;

namespace SnappetChallenge.BusinessLogicLayer.BusinessObjects
{
    public class TopStudentStatistic
    {
        public string Subject { get; set; }
        public Dictionary<long, int> TopStudentList { get; set; }
        public Dictionary<long, int> BottomStudentList { get; set; }
    }
}