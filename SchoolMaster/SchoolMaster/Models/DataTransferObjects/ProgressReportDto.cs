using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolMaster.Database.QueryModels;

namespace SchoolMaster.Models.DataTransferObjects
{
    public class ProgressReportDto
    {
        public ICollection<AggregateResultSet<int, double>> Average { get; set; }
        public ICollection<AggregateResultSet<int, double>> Minimum { get; set; }
        public ICollection<AggregateResultSet<int, double>> Maximum { get; set; }
    }
}
