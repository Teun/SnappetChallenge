using System;
using System.ComponentModel.DataAnnotations;

namespace SnappetChallenge.Models.ViewModels
{
    public class CorrectAnswerRequest
    {
        [Required]
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
    }
}
