namespace SnappetChallenge.Core
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Main api resposnse class
    /// </summary>
    /// <typeparam name="T">Type of data in reponse</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the report items.
        /// </summary>
        /// <value>
        /// The report items.
        /// </value>
        public List<T> ReportItems { get; set; }

        /// <summary>
        /// Gets or sets the items count.
        /// </summary>
        /// <value>
        /// The items count.
        /// </value>
        public int ItemsCount { get; set; }

        /// <summary>
        /// Gets or sets the lesson date.
        /// </summary>
        /// <value>
        /// The lesson date.
        /// </value>
        public DateTime? LessonDate { get; set; }

        /// <summary>
        /// Gets or sets the error MSG.
        /// </summary>
        /// <value>
        /// The error MSG.
        /// </value>
        public string ErrorMsg { get; set; }
    }
}
