namespace SnappetChallenge.WebUI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SnappetChallenge.WebUI.Models;

    public class SubjectViewModel
    {
        public SubjectViewModel() { }

        public SubjectViewModel(SubjectModel subject)
        {
            if (subject != null)
            {
                this.Name = subject.Name;
                this.LearningObjective = subject.LearningObjective;
                this.Answers = subject.Answers.Select(item => new ExerciseResultViewModel(item));
                this.AnswerCount = this.Answers.Count();
                this.CorrectAnswerCount = this.Answers.Count(x => x.IsCorrect);
                this.CorrectnessPercent = (float)this.CorrectAnswerCount / (float)this.AnswerCount * 100;
            }
        }

        public string Name { get; set; }

        public string LearningObjective { get; set; }

        public int AnswerCount { get; set; }

        public int CorrectAnswerCount { get; set; }

        public float CorrectnessPercent { get; set; }

        public IEnumerable<ExerciseResultViewModel> Answers { get; set; }
    }
}
