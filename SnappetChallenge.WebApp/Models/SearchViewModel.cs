using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.WebApp.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
            Students = new List<string>();
            Subjects = new List<string>();
            Domains = new List<string>();
            LearningObjectives = new List<string>();
        }
        public List<string> Students { get; set; }
        public List<string> Subjects { get; set; }
        public List<string> Domains { get; set; }
        public List<string> LearningObjectives { get; set; }
        public DateTime startDate => new DateTime(2015, 3, 1, 0, 0, 0);
        public DateTime endDate => new DateTime(2015, 3, 24, 23, 59, 59);
        
    }
}