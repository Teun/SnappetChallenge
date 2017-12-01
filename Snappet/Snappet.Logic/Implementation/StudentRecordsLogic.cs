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
            //get parser instance
            IParser parser = SimpleResolver.GetInstance<IParser>();
            //get config instance to get the file path, then load the records
            var result = parser.Parse(SimpleResolver.GetInstance<IAppConfig>().DataFilePath);
            List<StudentProgressRecord> progressResult = new List<StudentProgressRecord>();
            
            //goes through the result dictionary
            foreach (var item in result)
            {
                var record = new StudentProgressRecord() { StudentID = item.Key };
                //get the records that match the date
                var matchingRecords = item.Value.Where(r => r.SubmitDateTime.Date == date);
                var domainExcercies = new Dictionary<string, DomainResult>();

                //go through the matching records
                foreach (var progressRecord in matchingRecords)
                {
                    //add the domain results
                    //this will be used to show the success rate for this student, on that day, for each domain
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

                    //add in this records progress
                    //the progress list will show a graph for that student on that day
                    record.Progress.Add(progressRecord.Progress);
                    //will use the progress submit time as a label on the x-axis
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
            //loop through the date range
            while (current <= to)
            {
                //skip weekends
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    var matchingRecords = studentRecords.Where(r => r.SubmitDateTime.Date == current);
                    if (matchingRecords.Count() > 0)
                    {
                        //get progress average for that day
                        daysProgress.Add(matchingRecords.Average(r => r.Progress));
                        //get success rate for that day
                        daysSuccessRate.Add(matchingRecords.Where(r => r.Correct).Count() / (double)matchingRecords.Count() * 100);
                    }
                    else
                    {
                        //just in case this day has no records
                        daysProgress.Add(0);
                        daysSuccessRate.Add(0);
                    }
                }
                current = current.AddDays(1);
            }
        }
    }
}
