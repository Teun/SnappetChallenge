using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ClassWorkResult
    {
        public int UserId { get; set; }
        public int NumberOfExercises { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public decimal CorrectPercentage => (CorrectAnswers / NumberOfQuestions) * 100;
        public int IncorrectAnswers { get; set; }
        public decimal IncorrectPercentage => (IncorrectAnswers / NumberOfQuestions) * 100;
        public int TotalProgress { get; set; }
    }
}
