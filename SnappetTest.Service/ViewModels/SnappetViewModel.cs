using SnappetTest.Model.Entities;
namespace SnappetTest.Service.ViewModels
{
    public class SnappetViewModel
    {
      public int AnswersCount { get; set; }
      public int CorrectAnswersCount { get; set; }
      
      public string DateRequested { get; set; }
      public int ProgessCount { get; set; }
      public string Subject { get; set; }
   
    }
}
