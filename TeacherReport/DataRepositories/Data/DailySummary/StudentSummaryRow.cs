using System;
using System.Collections.Generic;
using System.Linq;

namespace DataRepositories.Data.DailySummary
{
    /// <summary>
    /// Contains the summary row for an individual student in the daily student summary
    /// </summary>
    public class StudentSummaryRow
    {
        /// <summary>
        /// Gets or sets a dictionary where the key is the name of a subject and the value
        /// is the student's average progress in that subject
        /// </summary>
        public Dictionary<string, decimal> AverageSubjectProgress { get; set; }

        /// <summary>
        /// Gets or sets the student's user ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the student
        /// </summary>
        /// <remarks>
        /// This this anonymized data, the name will be assigned the User ID, but in a real
        /// application, this would contain the student's actual name.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets the average progress score for all subjects
        /// </summary>
        public decimal OverallAverageProgress
        {
            get
            {
                return AverageSubjectProgress.Values.Average();
            }
        }
    }
}
