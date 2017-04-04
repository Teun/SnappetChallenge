using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.SnappetChallenge.Data.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        /// <summary>
        /// Get user progress data for multiple users on specific subject filtered by date.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="dayFilter"></param>
        /// <returns></returns>
        public List<AggregatedProgressData> GetSubjectData(string subject, DateTime dateFilter)
        {
            DateTime startDateUTC = dateFilter.ToUniversalTime();
            DateTime endDateUTC = startDateUTC.AddDays(1);

            using (SnappetModelContainer container = new SnappetModelContainer())
            {
                var query = from apd in container.AggregatedProgressData
                            where apd.SubmitDateTime >= startDateUTC &&
                                  apd.SubmitDateTime <= endDateUTC &&
                                  apd.Subject.Equals(subject, StringComparison.CurrentCultureIgnoreCase)
                            select apd;

                return query.ToList();
            }
        }

        /// <summary>
        /// Get a list of distinct subjects on a specific day.
        /// </summary>
        /// <param name="dateFilter"></param>
        /// <returns></returns>
        public List<string> GetSubjects(DateTime dateFilter)
        {
            DateTime startDateUTC = dateFilter.ToUniversalTime();
            DateTime endDateUTC = startDateUTC.AddDays(1);

            using (SnappetModelContainer container = new SnappetModelContainer())
            {
                var query = (from apd in container.AggregatedProgressData
                            where apd.SubmitDateTime >= startDateUTC &&
                                  apd.SubmitDateTime <= endDateUTC
                            select apd.Subject).Distinct().OrderBy(subject => subject);

                return query.ToList();
            }
        }

        /// <summary>
        /// Get user progress data for a single user on specific subject filtered by date.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="subject"></param>
        /// <param name="dateFilter"></param>
        /// <returns></returns>
        public List<AggregatedProgressData> GetUserData(int userId, string subject, DateTime dateFilter)
        {
            DateTime startDateUTC = dateFilter.ToUniversalTime();
            DateTime endDateUTC = startDateUTC.AddDays(1);

            using (SnappetModelContainer container = new SnappetModelContainer())
            {
                var query = from apd in container.AggregatedProgressData
                            where apd.SubmitDateTime >= startDateUTC &&
                                  apd.SubmitDateTime <= endDateUTC &&
                                  apd.UserId.Equals(userId) &&
                                  apd.Subject.Equals(subject, StringComparison.CurrentCultureIgnoreCase)
                            select apd;

                return query.ToList();
            }
        }
    }
}
