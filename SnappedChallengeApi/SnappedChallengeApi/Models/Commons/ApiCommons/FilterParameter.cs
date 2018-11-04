using System;

namespace SnappedChallengeApi.Models.Commons.ApiCommons
{
    /// <summary>
    /// Post data body parameter
    /// </summary>
    public class FilterParameter
    {
        /// <summary>
        /// Start Date
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End Date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
