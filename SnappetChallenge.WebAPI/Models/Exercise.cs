using SnappetChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnappetChallenge.WebAPI.Models
{
    public class Exercise
    {
        public Exercise(IEnumerable<SubmittedAnswer> answers)
        {
            var answerList = answers.ToList();
            if (!answerList.Any()) return;
            this.Id = answerList.First().ExerciseId;
            this.Difficulty = answerList.First().Difficulty;
            this.NrAnswered = answerList.Count;
            this.NrAnsweredCorrectly = answerList.Count(x => x.IsCorrect);
        }

        public int Id { get; set; }

        public double Difficulty { get; set; }

        public int NrAnswered { get; set; }

        public int NrAnsweredCorrectly { get; set; }
    }
}