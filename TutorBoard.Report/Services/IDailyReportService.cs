using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TutorBoard.Report.Dtos;

namespace TutorBoard.Report.Services
{
    public interface IDailyReportService
    {
        /// <summary>
        /// Create daily report for given date
        /// </summary>
        /// <param name="date">Date of the report</param>
        /// <returns>DailyReportDto</returns>
        Task<DailyReportDto> CreateDailyReportAsync(DateTime date);

        /// <summary>
        /// Create a report about edited tasks. Complete and per subject
        /// </summary>
        /// <param name="date">Date of the report</param>
        /// <returns>EditedTaskReportDto</returns>
        Task<EditedTasksReportDto> CreateEditedTasksReportAsync(DateTime date);

        /// <summary>
        /// Create a report about every users progress on given date
        /// </summary>
        /// <param name="date">Date of the report</param>
        /// <returns>List of UserProgressReportDto</returns>
        Task<IEnumerable<UserProgressReportDto>> CreateUserProgressReportsAsync(DateTime date);
    }
}
