using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepositories.Data.DailySummary
{
    /// <summary>
    /// Contains a daily student summary
    /// </summary>
    public class DailyStudentSummary
    {
        /// <summary>
        /// Gets or sets a list of unique subjects contained in the daily summary
        /// </summary>
        public List<string> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the collection of student summary rows
        /// </summary>
        public List<StudentSummaryRow> SummaryRows { get; set; }
    }
}
