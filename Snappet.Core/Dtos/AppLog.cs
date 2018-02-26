using System;

namespace Snappet.Core.Dtos
{
    public class AppLog
    {
        public string LogMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime LogDate { get; set; }
        public long Id { get; set; }
    }
}
