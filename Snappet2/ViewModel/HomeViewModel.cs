using Snappet2.Models;
using System;
using System.Collections.Generic;

namespace Snappet2.ViewModel
{
    public class HomeViewModel
    {
        public DateTime ReportDateTime { get; set; }
        public List<SubmittedAnswer> SubmittedAnswers { get; set; }
    }
}
