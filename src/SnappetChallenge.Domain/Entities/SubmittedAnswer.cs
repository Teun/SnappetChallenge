using SnappetChallenge.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnappetChallenge.Domain.Entities;

[Table("SubmittedAnswer")]
public class SubmittedAnswer
{
    public int SubmittedAnswerId { get; set; }
    public DateTime SubmitDateTime { get; set; }
    public bool Correct { get; set; }
    public int Progress { get; set; }
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public string Difficulty { get; set; }
    public string Subject { get; set; }
    public string Domain { get; set; }
    public string LearningObjective { get; set; }
    
}