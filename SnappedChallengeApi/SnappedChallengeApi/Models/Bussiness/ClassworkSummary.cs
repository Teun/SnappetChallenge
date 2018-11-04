using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.Models.Bussiness
{
    /// <summary>
    /// Sometimes entities are not enough so we procudes other bussiness models to supply data for the services
    /// This model is being filled with the real entity data after grouping and calculations
    /// </summary>
    public class ClassworkSummary
    {
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Domain
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Learning Objective
        /// </summary>
        public string LearningObjective { get; set; }
        /// <summary>
        /// Exercise Count
        /// </summary>
        public int ExerciseCount { get; set; }
        /// <summary>
        /// Correct Answr Count
        /// </summary>
        public int CorrectAnswerCount { get; set; }
        /// <summary>
        /// Wrong Answer Count
        /// </summary>
        public int WrongAnswerCount { get; set; }
        /// <summary>
        /// Student Count
        /// </summary>
        public int StudentCount { get; set; }
        /// <summary>
        /// Total Progress Point
        /// </summary>
        public decimal TotalProgress { get; set; }
        /// <summary>
        /// Total Progress Per Student 
        /// </summary>
        public decimal TotalProgressPerStudent { get; set; }
        /// <summary>
        /// Result has problem to be seen for the viewer or not
        /// </summary>
        public bool HasProblem { get; set; }

        /// <summary>
        /// After read calculations method
        /// </summary>
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
