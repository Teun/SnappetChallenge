using System;
using System.Collections.Generic;
using System.Text;

namespace SnappetChallengAPI.Model
{
    public class FilterReport
    {
        public FilterReport()
        {
            SkipRows = 0;
            TakeRows = 20;
        }
        public List<string> Subject { get; set; }
        public List<string> Domain { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SkipRows { get; set; }
        public int TakeRows { get; set; }
    }
}
