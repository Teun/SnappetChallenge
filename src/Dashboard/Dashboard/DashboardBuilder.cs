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

            IReadOnlyCollection<Answer> periodAnswers = answers
                .Where(answer => answer.SubmitDateTime >= from && answer.SubmitDateTime <= to)
                .ToList();

            var dashboard = new Models.Dashboard();

            dashboard.Start = from;
            dashboard.End = to;

            dashboard.StudentsPresent = periodAnswers.GroupBy(answer => answer.UserId).Count();

            dashboard.SlicedStatistics = BuildHierarchicalSlices(periodAnswers);

            return dashboard;
        }

        private AnswersSlice BuildHierarchicalSlices(IReadOnlyCollection<Answer> answers)
        {
            return new AnswersSlice("Overall", answers, GroupBySubject(answers));
        }

        private IReadOnlyCollection<AnswersSlice> GroupBySubject(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.Subject)
                .Select(group => new AnswersSlice(group.Key, group.ToList(), GroupByDomain(group)))
                .ToList();
        }

        private IReadOnlyCollection<AnswersSlice> GroupByDomain(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.Domain)
                .Select(group => new AnswersSlice(group.Key, group.ToList(), GroupByLearningObjective(group)))
                .ToList();
        }

        private IReadOnlyCollection<AnswersSlice> GroupByLearningObjective(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.LearningObjective)
                .Select(group => new AnswersSlice(group.Key, group.ToList(), new List<AnswersSlice>(0)))
                .ToList();
        }
    }
}
