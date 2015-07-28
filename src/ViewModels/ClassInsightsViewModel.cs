using System;
using System.Collections.Generic;

using SnappetChallenge.Models;

namespace SnappetChallenge.ViewModels
{
    public class ClassInsightsViewModel
    {
        public string RequestedDate { get; set; }
        public int AmountOfAnswers { get; set; }
        public int AmountOfAnswersCorrect { get; set; }
        public int TotalProgress { get; set; }
        public User MostProgress { get; set; }
        public LearningObjective MostDifficultyWith { get; set; }
        public IEnumerable<LearningObjective> TopObjectivesStudied { get; set; }
    }
}
