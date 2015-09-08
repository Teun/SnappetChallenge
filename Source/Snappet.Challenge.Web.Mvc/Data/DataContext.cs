using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Snappet.Challenge.Web.Mvc.Data.DTOs;

namespace Snappet.Challenge.Web.Mvc.Data
{
    /// <summary>
    /// This is the class to work with the data
    /// The provided .json file is our datasource
    /// </summary>    
    public class DataContext
    {
        private static SubmittedAnswer[] _submittedAnswers;

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataContext() {
            _submittedAnswers = ReadDataSource();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the students that have submitted answers for a given day (and time)
        /// </summary>
        /// <param name="timeOnDay">Date and time to get the students for</param>
        /// <returns>Array of <see cref="Student"/></returns> objects
        public Student[] GetStudents(DateTime timeOnDay) {
            var result = _submittedAnswers
                .Where(
                    x => x.SubmitDateTime > timeOnDay.Date
                         && x.SubmitDateTime < timeOnDay
                )
                .GroupBy(g => new
                {
                    g.UserId
                })
                .Select((group => new Student
                {
                    Id = group.Key.UserId
                }));

            return result.ToArray();
        }

        /// <summary>
        /// Gets the activities for the entire class for a given day (and time)
        /// </summary>
        /// <param name="timeOnDay">Date and time to get the students for</param>
        /// <returns>Array of <see cref="SubjectActivity"/></returns> objects
        public SubjectActivity[] GetClassActivityForTimeOnDay(DateTime timeOnDay)
        {
            var result = _submittedAnswers
                .Where(
                    x => x.SubmitDateTime > timeOnDay.Date
                    && x.SubmitDateTime < timeOnDay
                )
                .GroupBy(g => new
                {
                    g.Subject
                })
                .Select(group => new SubjectActivity
                {
                    Subject = group.Key.Subject,
                    Progress = group.Sum(x => x.Progress),
                    NrOfSubmittedAnswers = group.Count()
                });

            return result.ToArray();
        }

        /// <summary>
        /// Gets the activity for a specific student for a given day (and time)
        /// </summary>
        /// <param name="userId">Id of the student to get the activities for</param>
        /// <param name="timeOnDay">Date and time to get the students for</param>
        /// <returns>Array of <see cref="SubjectActivity"/></returns> objects
        public SubjectActivity[] GetStudentActivityForTimeOnDay(int userId, DateTime timeOnDay)
        {
            var result = _submittedAnswers
                .Where(
                    x => x.SubmitDateTime > timeOnDay.Date
                    && x.SubmitDateTime < timeOnDay
                    && x.UserId == userId
                )
                .GroupBy(g => new
                {
                    g.UserId,
                    g.Subject
                })
                .Select(group => new SubjectActivity
                {
                    Subject = group.Key.Subject,
                    Progress = group.Sum(x => x.Progress),
                    NrOfSubmittedAnswers = group.Count()
                });

            return result.ToArray();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Reads json data file
        /// </summary>
        /// <returns>Array of <see cref="SubmittedAnswer"/></returns> objects
        private SubmittedAnswer[] ReadDataSource()
        {
            string dataSourceFullPath = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "work.json");
            SubmittedAnswer[] submittedAnswers;

            using (StreamReader file = File.OpenText(dataSourceFullPath))
            {
                JsonSerializer serializer = new JsonSerializer
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };
                submittedAnswers = (SubmittedAnswer[])serializer.Deserialize(file, typeof(SubmittedAnswer[]));
            }

            return submittedAnswers;
        }

        #endregion

    }
}