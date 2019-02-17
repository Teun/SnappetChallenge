
using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Domain;

namespace Dashboard.Dashboard.Models
{
    /// <summary>
    /// Represents a subset of answers
    /// </summary>
    public class AnswersSlice
    {
        public string Name { get; }

        /// <summary>
        /// Collection of answers belong to this slice
        /// </summary>
        public IReadOnlyCollection<Answer> Answers { get; }

        /// <summary>
        /// More detailed slices of the data
        /// </summary>
        public IReadOnlyCollection<AnswersSlice> Subslices { get;  }

        public AnswersSlice(string name, IReadOnlyCollection<Answer> answers, IReadOnlyCollection<AnswersSlice> subslices)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Answers = answers ?? throw new ArgumentNullException(nameof(answers));
            Subslices = subslices ?? throw new ArgumentNullException(nameof(subslices));
        }

        public SliceStatistics GetStatistics()
        {
            int exerciseCount = Answers.GroupBy(answer => answer.ExerciseId).Count();

            float correctPercentage = (float)100 * Answers.Count(answer => answer.IsCorrect) / Answers.Count;

            return new SliceStatistics
            {
                ExerciseCount = exerciseCount,
                CorrectPercentage = correctPercentage
            };
        }
    }
}
