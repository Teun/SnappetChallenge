using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.Json
{
    public class Answer
    {
        public string SubmittedAnswerId;
        public DateTime SubmitDateTime;
        public int Correct;
        public string Progress;
        public string UserId;
        public string ExerciseId;
        public string Difficulty; 
        public string Subject;
        public string Domain;
        public string LearningObjective;
    }
}