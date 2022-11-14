using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SnappetChallenge.Client.Model
{
    public class FilterReport
    {
        public FilterReport()
        {
            Subject = new List<string>();
            Domain = new List<string>();
            TakeRows = 25;
        }

        public List<string> Subject { get; set; }
        public List<string> Domain { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SkipRows { get; set; }
        public int TakeRows { get; set; }
    }
}
