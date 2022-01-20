using System.ComponentModel.DataAnnotations;

namespace Snappet.GraphQL.API.Model
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        [Required]
        public int SubmittedAnswerId { get; set; }
        public SubmittedAnswers SubmittedAnswers { get; set; }
    }
}
