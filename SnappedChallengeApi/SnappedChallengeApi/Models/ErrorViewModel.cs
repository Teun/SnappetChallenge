using System;

namespace SnappedChallengeApi.Models
{
    /// <summary>
    /// Default Error View Model For Error Controller and Error View
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request Id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Show Request Id
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}