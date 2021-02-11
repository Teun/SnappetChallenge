using System.Collections.Generic;
using SchoolMaster.Database.QueryModels;

namespace SchoolMaster.Models.DataTransferObjects
{
    public class ProgressReportDto
    {
        public ICollection<HourValuePair> Average { get; set; }
        public ICollection<HourValuePair> Minimum { get; set; }
        public ICollection<HourValuePair> Maximum { get; set; }
    }
}