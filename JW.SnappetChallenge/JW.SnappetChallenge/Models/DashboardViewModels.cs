using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JW.SnappetChallenge.Models
{
    /// <summary>
    /// Dashboard index view model containing a list of subjects for a certain date.
    /// </summary>
    public class DashboardIndexViewModel
    {
        public DateTime Date { get; set; }
        public List<string> Subjects { get; set; }
    }

    /// <summary>
    /// View model containing list of progress per user of <paramref name="Subject"/> on <paramref name="Date"/>
    /// </summary>
    public class SubjectSummaryViewModel
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Progress> UserProgress { get; set; }
    }

    /// <summary>
    /// View model containing a summary of user progress data.
    /// </summary>
    public class UserSummaryViewModel
    {
        public string User { get; set; }
        public DateTime Date { get; set;  }
        public IEnumerable<Progress> LearningObjectiveProgress { get; set; }
    }
}