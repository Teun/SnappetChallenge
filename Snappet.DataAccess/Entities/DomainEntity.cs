using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet.DataAccess
{
    [Table("Domain")]
    public class DomainEntity
    {
        public DomainEntity()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
