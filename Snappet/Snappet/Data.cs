using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Snappet.Models.DataModels;

namespace Snappet
{
    public class DataSource
    {
        static DateTime todayDate = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

        public static SubmittedAnswer[] LoadData()
        {
            SubmittedAnswer[] submittedAnswers;

            // Get the correct file path
            var dataPath = AppDomain.CurrentDomain.BaseDirectory.ToString(); 
            var filePath = Path.Combine(dataPath, "WorkData\\work.json");

            // Serialize Json to objects
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer()
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };

                submittedAnswers = (SubmittedAnswer[])serializer.Deserialize(file, typeof(SubmittedAnswer[]));
            }

            // Return only the answers until today
            var answers = submittedAnswers.Where(x => x.SubmitDateTime < todayDate).ToArray();

            return answers; 
        }

        public static IEnumerable<SubmittedAnswer> TodayResults()
        {
            var answers = LoadData();
            var startDate = new DateTime(2015, 03, 24, 00, 00, 00, DateTimeKind.Utc);

            // Get the average progress per subject for today
            var todaysAnswers = answers.Where(x => x.SubmitDateTime < todayDate && x.SubmitDateTime > startDate);

            return todaysAnswers;
        }

        public static IEnumerable<AverageProgress> AverageProgress()
        {
            var todaysAnswers = TodayResults();

            IEnumerable<AverageProgress> averages = todaysAnswers.GroupBy(g => g.Subject, p => p.Progress).Select(g => new AverageProgress
            {
                Subject = g.Key,
                Average= g.Average()
            });

            return averages;
        }
    }
}