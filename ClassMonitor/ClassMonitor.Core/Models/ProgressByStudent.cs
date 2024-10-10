namespace ClassMonitor.Core.Models
{
    public class ProgressByStudent
    {
        public required DateTime DateTime { get; set; }
        public required string StudentName { get; set; }
        public required int? Progress { get; set; }
    }
}
