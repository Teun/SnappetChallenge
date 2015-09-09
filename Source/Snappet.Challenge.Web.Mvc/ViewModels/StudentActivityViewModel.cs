using Snappet.Challenge.Web.Mvc.Data.DTOs;

namespace Snappet.Challenge.Web.Mvc.ViewModels
{
    public class StudentActivityViewModel
    {

        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets an array of <see cref="SubjectActivity"/> objects
        /// </summary>
        public SubjectActivity[] StudentActivity { get; set; }
    }
}