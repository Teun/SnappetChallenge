using Snappet.Contracts.Assesments.Contracts;
using Snappet.Contracts.Assesments.Models;
using Snappet.Contracts.Assesments.ViewModels;
using Snappet.Contracts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snappet.Services.Assesments
{
    public class ResultsProcessor : IResultsProcessor
    {        
        public ClassModel GetProgress(TotalResult workResults, DateTimeOffset dateTime, PeriodType periodType)
        {            
            var classModel = new ClassModel() { Period = periodType.DisplayName(),
                CurrentDate = dateTime.DateTime.ToUniversalTime(),
                PreviousResultType = periodType.DisplayName() };
            
            var currentResults = workResults.ExcercisesResults.Where(wr => wr.SubmitDateTime.DayOfYear == dateTime.DayOfYear
                                                                     && wr.SubmitDateTime <= dateTime);

            var todaysSubjects = currentResults.GroupBy(pr => pr.Subject);

            var subjectList = todaysSubjects.Select(ts => ts.Key);

            classModel.TotalProgress = FillTotalProgress(workResults, todaysSubjects, currentResults, dateTime).ToList();            

            foreach (var subject in subjectList)
            {
                var currentSubjectResult = currentResults.Where(cr => cr.Subject == subject)
                                          .Select(s => new { s.UserId, s.Progress })
                                          .GroupBy(s => s.UserId).Select(group => 
                                          new { UserId = group.Key, AverageResult = group.Average(el => el.Progress)})
                                          .ToList();
               
                var sm = new SubjectModel() { Subject = subject, Users = new List<StudentModel>() };

                currentSubjectResult.ForEach(sr => sm.Users.Add(new StudentModel(sr.UserId, sr.AverageResult)));
                classModel.ResultsPerSubjects.Add(sm);
            }

            FillPreviousResult(classModel, workResults, dateTime);

            classModel.ResultsPerSubjects.ForEach(subject => subject.Users = subject.Users.OrderByDescending(u => u.Result).ToList());
            return classModel;
        }

        private IEnumerable<StatiscticsModel> FillTotalProgress(TotalResult workResults, IEnumerable<IGrouping<string,ExcerciseResult>> todaysSubjects, 
                                        IEnumerable<ExcerciseResult> currentResults, DateTimeOffset currentDateTime)
        {            
            foreach (var subject in todaysSubjects)
            {
                var previousCurrentSubjectDay = workResults.ExcercisesResults.Where(wr => wr.SubmitDateTime.DayOfYear < currentDateTime.DayOfYear
                                                                                    && wr.Subject == subject.Key)
                                             .OrderByDescending(wr => wr.SubmitDateTime).Select(wr => wr.SubmitDateTime)
                                             .FirstOrDefault();

                var progress = 0;
                var currentTotalProgress = currentResults.Where(pr => pr.Subject == subject.Key).Average(wr => wr.Progress);

                progress = (int)(Math.Round(currentTotalProgress, 0));
                if (previousCurrentSubjectDay != null)
                {
                    var previousResults = workResults.ExcercisesResults.Where(wr => wr.SubmitDateTime.DayOfYear == previousCurrentSubjectDay.DayOfYear
                                                                                && wr.Subject == subject.Key);

                    var previousTotalProgress = previousResults.Average(wr => wr.Progress);
                    progress = (int)(Math.Round(currentTotalProgress - previousTotalProgress, 0));
                }
                yield return new StatiscticsModel() { Subject = subject.Key, Result = progress };
            }
        }

        private void FillPreviousResult(ClassModel classModel, TotalResult workResults, DateTimeOffset currentDateTime)
        {
            foreach(var currentResult in classModel.ResultsPerSubjects)
            {
                foreach (var currentUser in currentResult.Users)
                {
                    var previousSubjectUserDay = workResults.ExcercisesResults.Where(wr => wr.SubmitDateTime.DayOfYear < currentDateTime.DayOfYear
                                                        && wr.Subject == currentResult.Subject
                                                        && wr.UserId == currentUser.Id)
                                                        .OrderByDescending(wr => wr.SubmitDateTime).Select(wr => wr.SubmitDateTime)
                                                        .FirstOrDefault();

                    var previousSubjectUserResult = workResults.ExcercisesResults
                            .Where(wr => wr.SubmitDateTime.DayOfYear == previousSubjectUserDay.DayOfYear
                            && wr.Subject == currentResult.Subject && wr.UserId == currentUser.Id);

                    var averagePreviousSubjectUserResult = 0.0;
                    if(previousSubjectUserResult.Count() > 0)
                        averagePreviousSubjectUserResult = previousSubjectUserResult.Average(cr => cr.Progress);

                    var currentSubject = classModel.ResultsPerSubjects.Single(s => s.Subject == currentResult.Subject);
                    var currentSubjectUser = currentSubject.Users.Single(u => u.Id == currentUser.Id);
                    currentSubjectUser.Result = Math.Round(currentSubjectUser.Result - averagePreviousSubjectUserResult, 0);
                }
            }     
        }
    }
}
