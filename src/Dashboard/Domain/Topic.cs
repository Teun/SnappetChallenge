using System;
using System.Collections.Generic;
using System.Linq;

namespace Dashboard.Domain
{
    /// <summary>
    /// Represents a subset of answers
    /// </summary>
    public class Topic
    {
        public string Name { get; }

        /// <summary>
        /// Collection of answers belong to this topic
        /// </summary>
        private readonly IReadOnlyCollection<Answer> _answers;

        /// <summary>
        /// More detailed topics decomposition
        /// </summary>
        public IReadOnlyCollection<Topic> Subtopics { get;  }

        public Topic(string name, IReadOnlyCollection<Answer> answers, IReadOnlyCollection<Topic> subtopics)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _answers = answers ?? throw new ArgumentNullException(nameof(answers));
            Subtopics = subtopics ?? throw new ArgumentNullException(nameof(subtopics));
        }

        public TopicStats GetStatistics()
        {
            int exerciseCount = _answers.GroupBy(answer => answer.ExerciseId).Count();

            int correctAnswersCount = _answers.Count(it => it.IsCorrect);

            int studentsCount = _answers.GroupBy(answer => answer.UserId).Count();

            return new TopicStats(exerciseCount, _answers.Count, correctAnswersCount, studentsCount);
        }
    }
}
