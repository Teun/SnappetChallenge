using System;
using System.Collections;
using System.Collections.Generic;
using Snappet.Challenge.Web.Core.Models;

namespace Snappet.Challenge.Web.Core.ViewModel
{
    public class StudentHistoryViewModel
    {
        public DateTime Date { get; set; }
        public IList<LearningObjectiveSummaryViewModel> LearningObjectiveSummary { get; set; }
    }
}