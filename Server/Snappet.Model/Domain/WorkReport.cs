using System.Collections.Generic;

namespace Snappet.Model.Domain
{
    public class WorkReport
    {
        public string LearningObjective { get; set; }

        public int Progress { get; set; }

        public int TotalExerices { get; set; }

        public int TotalStudents { get; set; }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public List<StudentDetail> StudentDetails { get; set; }

    }
}
