using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataRepositories.Data.DailySummary;

namespace TeacherReport.Models
{
    /// <summary>
    /// Provides the view model for the summary page
    /// </summary>
    public class SummaryPageViewModel
    {
        /// <summary>
        /// Gets or sets the daily student summary
        /// </summary>
        public DailyStudentSummary StudentSummary { get; set; }
    }
}
