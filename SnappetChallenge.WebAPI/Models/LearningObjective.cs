using SnappetChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.WebAPI.Models
{
    public class LearningObjective
    {
        public LearningObjective(IEnumerable<SubmittedAnswer> answers)
        {
            var answerList = answers.ToList();
            this.Subject = answers.First().Subject;
            this.Domain = answers.First().Domain;
            this.Objective = answers.First().LearningObjective;
            var exercises = answers.GroupBy(x => x.ExerciseId).ToList();
            this.Exercises = exercises.Select(x => new Exercise(x)).ToList();
            this.FirstQuestionAnswered = answers.Min(x => x.SubmittedDateTime);
        }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public string Objective { get; set; }

        public List<Exercise> Exercises { get; set; }

        public DateTime FirstQuestionAnswered { get; set; }
    }
}