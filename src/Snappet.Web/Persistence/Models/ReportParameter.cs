namespace Snappet.Web.Persistence.Models
{
    public class ReportParameter
    {
        public int Id { get; set; }
        public int ReportConfigurationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}