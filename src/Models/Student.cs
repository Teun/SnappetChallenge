using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int CurrentProgress { get; set; }
        public int CorrectAttempts { get; set; }
        public int InCorrectAttempts { get; set; }
        public int UniqueExercises { get; set; }
        public int SubmittedAnswers { get; set; }
        public double AverageDifficulty { get; set; }
        public string Subject { get; set; }
    }
}
