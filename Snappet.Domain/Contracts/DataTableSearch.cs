
namespace Snappet.Domain.Contracts
{
    public class DataTableSearch
    {
        public int UserId { get; set; }
        public int DomainId { get; set; }
        public int Page { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public ColumnOrder Order { get; set; }
    }

    public class ColumnOrder
    {
        public string ColumnName { get; set; }
        public string Order { get; set; }
    }
}
