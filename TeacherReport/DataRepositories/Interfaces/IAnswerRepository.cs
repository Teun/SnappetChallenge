using System;
using System.Collections.Generic;
using System.Text;

using DataRepositories.Data;
using DataRepositories.Data.DailySummary;

namespace DataRepositories.Interfaces
{
    /// <summary>
    /// Defines the interface to the answer repository
    /// </summary>
    interface IAnswerRepository
    {
        /// <summary>
        /// Retrieves the daily student summary data as of a specific point in time
        /// </summary>
        /// <param name="summaryDateTime">The date/time when the summary is being retrieved</param>
        /// <returns>The daily student summary data as of the summary date/time</returns>
        List<DailyStudentSummary> GetDailyStudentSummary(DateTime summaryDateTime);
    }
}
