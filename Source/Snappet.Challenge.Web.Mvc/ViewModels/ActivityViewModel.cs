using System;
using Snappet.Challenge.Web.Mvc.Data.DTOs;

namespace Snappet.Challenge.Web.Mvc.ViewModels
{
    /// <summary>
    /// Viewmodel for the initial activity view
    /// </summary>
    public class ActivityViewModel
    {
        /// <summary>
        /// Gets or sets an array of <see cref="SubjectActivity"/> objects
        /// </summary>
        public SubjectActivity[] ClassActivity { get; set; }

        /// <summary>
        /// Gets or sets an array of <see cref="Student"/> objects
        /// </summary>
        public Student[] Students { get; set; }        

        /// <summary>
        /// Gets or sets a date/time stamp
        /// </summary>
        public DateTime DateTimeStamp { get; set; }
    }
}