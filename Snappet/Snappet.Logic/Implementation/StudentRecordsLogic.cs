using Snappet.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Logic
{
    public class StudentRecordsLogic : IStudentRecordsLogic
    {
        public IEnumerable<StudentProgressRecord> GetRecords(DateTime date)
        {
            IParser parser = SimpleResolver.GetInstance<IParser>();
            var result = parser.Parse(SimpleResolver.GetInstance<IAppConfig>().DataFilePath);
            List<StudentProgressRecord> progressResult = new List<StudentProgressRecord>();
            foreach (var item in result)
            {
                var record = new StudentProgressRecord() { StudentID = item.Key };
                var matchingRecords = item.Value.Where(r => r.SubmitDateTime.Date == date);
                var domainExcercies = new Dictionary<string, DomainResult>();
                foreach (var progressRecord in matchingRecords)
                {
                    DomainResult domainExercise;
                    if (domainExcercies.ContainsKey(progressRecord.Domain))
                    {
                        domainExercise = domainExcercies[progressRecord.Domain];
                        domainExercise.ExerciseCount++;
                    }
                    else
                    {
                        domainExercise = new DomainResult();
                        domainExcercies.Add(progressRecord.Domain, domainExercise);
                    }
                    if (progressRecord.Correct)
                        domainExercise.Correct++;
                    else domainExercise.Wrong++;

                    record.Progress.Add(progressRecord.Progress);
                    record.ProgressLabels.Add(progressRecord.SubmitDateTime.ToShortTimeString());
                }
                record.Exercises = domainExcercies;
                progressResult.Add(record);
            }

            return progressResult;
        }

        public void GetProgressDetails(int studentID, DateTime from, DateTime to,
            out List<double> daysProgress, out List<double> daysSuccessRate)
        {
            IParser parser = SimpleResolver.GetInstance<IParser>();
            var result = parser.Parse(SimpleResolver.GetInstance<IAppConfig>().DataFilePath);

            daysProgress = new List<double>();
            daysSuccessRate = new List<double>();

            var studentRecords = result[studentID];
            DateTime current = from;
            while (current <= to)
            {
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    var matchingRecords = studentRecords.Where(r => r.SubmitDateTime.Date == current);
                    if (matchingRecords.Count() > 0)
                    {
                        daysProgress.Add(matchingRecords.Average(r => r.Progress));
                        daysSuccessRate.Add(matchingRecords.Where(r => r.Correct).Count() / (double)matchingRecords.Count() * 100);
                    }
                    else
                    {
                        daysProgress.Add(0);
                        daysSuccessRate.Add(0);
                    }
                }
                current = current.AddDays(1);
            }
        }
    }
}
