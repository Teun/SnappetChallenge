namespace SnappetChallenge.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;

    /// <summary>
    /// Interface for report db layer
    /// </summary>
    public interface IReportDatabaseLayer
    {
        /// <summary>
        /// Adds the class report item.
        /// </summary>
        /// <param name="itemLst">The item LST.</param>
        /// <returns>Task result</returns>
        Task AddClassReportItem(List<ReportItem> itemLst);

        /// <summary>
        /// Gets the report item asynchronous.
        /// </summary>
        /// <param name="repDate">The rep date.</param>
        /// <returns>Result with api report items</returns>
        Task<List<ApiReportItem>> GetReportItemAsync(DateTime? repDate);
    }
}