using SnappetReports.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SnappetReports.Data
{
    public static class ReportData
    {
        private static string datafile = Path.GetFullPath("work.json");
        private static string workdata = File.ReadAllText(datafile);
        static List<ReportRecord> reportRecords = JsonConvert.DeserializeObject<List<ReportRecord>>(workdata);
        public static List<ReportRecord> workRecords = reportRecords;
    }
}
