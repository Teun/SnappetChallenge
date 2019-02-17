using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Dashboard.Models;
using Dashboard.Domain;

namespace Dashboard.Dashboard
{
    public class DashboardBuilder
    {
        public Models.Dashboard Build(IEnumerable<Answer> answers, DateTimeOffset from, DateTimeOffset to)
        {
            if (answers == null)
            {
                throw new ArgumentNullException(nameof(answers));
            }

            IEnumerable<Answer> periodAnswers = answers
                .Where(answer => answer.SubmitDateTime >= from && answer.SubmitDateTime <= to)
                .ToList();

            var dashboard = new Models.Dashboard();

            dashboard.Start = from;
            dashboard.End = to;

            dashboard.StudentsPresent = periodAnswers.GroupBy(answer => answer.UserId).Count();

            dashboard.OverallLearningResults = BuildLearningResults(periodAnswers);

            dashboard.OverallLearningResults.Detalization = periodAnswers
                .GroupBy(it => it.Subject)
                .ToDictionary(group => group.Key, BuildLearningResults);

            return dashboard;
        }

        private LearningResults BuildLearningResults(IEnumerable<Answer> answers)
        {
            var result = new LearningResults();

            answers = answers.ToList();

            result.ExerciseCount = answers.GroupBy(answer => answer.ExerciseId).Count();

            result.CorrectPercentage = (float)100 * answers.Count(answer => answer.IsCorrect) / answers.Count();
            
            return result;
        }
    }
}
