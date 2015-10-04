using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snappet.DataAccess
{
    [Table("LearningObjective")]
    public class LearningObjectiveEntity
    {
        public LearningObjectiveEntity()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
