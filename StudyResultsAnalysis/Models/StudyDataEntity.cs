namespace StudyResultsAnalysis.Models
{
  using System;
  using System.ComponentModel;
  using System.ComponentModel.DataAnnotations;

  public class StudyDataEntity
  {
    [Display(Name = "Answer Id")]
    public int SubmittedAnswerId { get; set; }

    [Display(Name = "Submit Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime SubmitDateTime { get; set; }


    public int Correct { get; set; }

    public int Progress { get; set; }

    [Display(Name = "Student Id")]
    [Range(1, int.MaxValue, ErrorMessage = "Input not valid")]
    public int UserId { get; set; }

    public int ExerciseId { get; set; }

    public string Difficulty { get; set; }

    public string Subject { get; set; }

    public string Domain { get; set; }

    public string LearningObjective { get; set; }
  }
}