using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Web.Contracts
{
    public class ReportConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ReportParameter> ReportParameters { get; set; }
    }

    public class ReportParameter
    {
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
