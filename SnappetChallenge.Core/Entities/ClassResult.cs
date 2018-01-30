using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.Core.Entities
{
    public class ClassResult
    {
        public long UserId { get; set; }
        public int NumberOfExercises { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public String CorrectPercentage
        {
            get
            {
                if (NumberOfQuestions != 0)
                {
                    return ((CorrectAnswers / NumberOfQuestions) * 100).ToString();
                }
                else
                {
                    return "0";
                }
            }
        }
        public int IncorrectAnswers { get; set; }
        public string IncorrectPercentage
        {
            get
            {
                if (NumberOfQuestions != 0)
                {
                    return ((IncorrectAnswers / NumberOfQuestions) * 100).ToString();
               
                }
                else
                {
                    return "0";
                }
            }
        } 
        public int TotalProgress { get; set; }
    }
}
