using Snappet.Contracts.Assesments.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.ViewModels
{
    public class ClassModel
    {
        public int Id { get; set; }        
        public string Period { get; set; }
        public List<StatiscticsModel> TotalProgress { get; set; }        
        public List<SubjectModel> ResultsPerSubjects { get; set; }
        public DateTime CurrentDate { get; set; }
        public string PreviousResultType { get; set; }

        public ClassModel()
        {
            TotalProgress = new List<StatiscticsModel>();
            ResultsPerSubjects = new List<SubjectModel>();
        }
    }
}
