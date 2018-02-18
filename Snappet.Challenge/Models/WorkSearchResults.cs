namespace Snappet.Challenge.Models
{
    public class WorkSearchResults
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public double CorrectRate { get; set; }
        public double AvgProgress { get; set; }
        public WorkItem[] WorkItems { get; set; }
    }
}
