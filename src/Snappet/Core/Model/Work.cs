using System;

namespace Snappet.Core.Model
{
    /**
     * De-normalized data representing the Assessment/Evaluation of
     * an Answer submitted to a given Exercise/Assignment. 
     */
    public class Work
    {
          public int SubmittedAnswerId { get; set; }
          public DateTime SubmitDateTime { get; set; }
          public int Correct { get; set; }
          public int Progress { get; set; }
          public int UserId { get; set; }
          public int ExerciseId { get; set; }          
          public double Difficulty { get; set; }
          public string Subject { get; set; }
          public string Domain { get; set; }
          public string LearningObjective { get; set; }
    }
}