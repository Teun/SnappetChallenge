using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Models
{
    public class TopStudentsViewModel
    {
        public string Subject { get; set; }
        public Dictionary<long, int> TopStudentList { get; set; }
        public Dictionary<long, int> BottomStudentList { get; set; }
    }
}