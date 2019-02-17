using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Domain;

namespace Dashboard.Dashboard
{
    public class DashboardBuilder
    {
        public Dashboard Build(IEnumerable<Answer> answers, DateTimeOffset from, DateTimeOffset to)
        {
            if (answers == null)
            {
                throw new ArgumentNullException(nameof(answers));
            }

            IEnumerable<Answer> periodAnswers = answers.Where(answer => answer.SubmitDateTime >= from && answer.SubmitDateTime <= to);

            var dashboard = new Dashboard();

            dashboard.Start = from;
            dashboard.End = to;

            dashboard.PupilsPresent = periodAnswers.GroupBy(answer => answer.UserId).Count();

            return dashboard;
        }
    }
}
