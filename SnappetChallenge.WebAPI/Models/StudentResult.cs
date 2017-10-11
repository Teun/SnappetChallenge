using SnappetChallenge.Data;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.WebAPI.Models
{
    public class StudentResult
    {
        public StudentResult(IEnumerable<SubmittedAnswer> answers)
        {
            var answersList = answers.ToList();
            this.Subject = answersList.First().Subject;
            this.Domain = answersList.First().Domain;
            this.NrAnswered = answersList.Count;
            this.NrAnsweredCorrectly = answersList.Count(x => x.IsCorrect);
        }

        public string Subject { get; set; }

        public string Domain { get; set; }

        public int NrAnswered { get; set; }

        public int NrAnsweredCorrectly { get; set; }
    }
}