using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.AggregateModels
{ 
    public abstract class ModelBase
    {
        [StringLength(200)]
        public string Subject { get; set; } = String.Empty;

        [StringLength(200)]
        public string Domain { get; set; } = String.Empty;

        [StringLength(200)]
        public string LearningObjective { get; set; } = String.Empty;
    }
}
