using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.Models.Bussiness
{
    public class ClassworkSummary
    {
        public DateTime Date { get; set; }
        public string Domain { get; set; }
        public string Subject { get; set; }
        public string LearningObjective { get; set; }
        public int ExerciseCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public int WrongAnswerCount { get; set; }
        public int StudentCount { get; set; }
        public decimal TotalProgress { get; set; }
        public decimal TotalProgressPerStudent { get; set; }
        public bool HasProblem { get; set; }

        public void Analyze()
        {
            if (StudentCount > 0)
                TotalProgressPerStudent = TotalProgress / StudentCount;

            if (CorrectAnswerCount < WrongAnswerCount)
                HasProblem = true;

            if (TotalProgress <= 0)
                HasProblem = true;

        }
    }
}
