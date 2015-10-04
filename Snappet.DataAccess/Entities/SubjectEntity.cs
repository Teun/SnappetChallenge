using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet.DataAccess
{
    [Table("Subject")]
    public class SubjectEntity
    {
        public SubjectEntity()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
