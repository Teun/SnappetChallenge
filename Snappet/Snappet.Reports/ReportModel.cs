namespace Snappet.Reports
{
    public abstract class ReportModel<TParameters>
    {
        public TParameters Parameters { get; set; }
        public string Title { get; set; }
    }
}
