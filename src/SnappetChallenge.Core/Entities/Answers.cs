using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappetChallenge.Core.Entities
{
    public class Answers
    {
        public Answers(IEnumerable<Answer> all)
        {
            All = all;
        }

        public IEnumerable<Answer> All { get; private set; }

        public int Total => All.Count();
        public int TotalCorrect => All.Count(x => x.IsCorrect);
        public int TotalIncorrect => Total - TotalCorrect;
        public decimal CorrectnessAverage => (100 * TotalCorrect) / Total;
        public double AverageProgress => All.Average(x => x.Progress);
    }

    public class Answer
    {
        public int Id { get; set; }
        public DateTime Submitted { get; set; }
        public bool IsCorrect { get; set; }
        public int Progress { get; set; }
    }
}
