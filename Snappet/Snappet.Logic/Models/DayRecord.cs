using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic.Models
{
    public class StudentProgressRecord
    {
        public int StudentID { get; set; }
        public Dictionary<string, DomainResult> Exercises { get; set; }
        public List<int> Progress { get; set; }
        public List<string> ProgressLabels { get; set; }
        public StudentProgressRecord()
        {
            Progress = new List<int>();
            ProgressLabels = new List<string>();
        }
    }

    public class DomainResult
    {
        public int ExerciseCount { get; set; }
        public int Correct { get; set; }
        public int Wrong { get; set; }

        /// <summary>
        /// Sets the exerciseCount to 1
        /// </summary>
        public DomainResult()
        {
            ExerciseCount = 1;
        }
    }
}
