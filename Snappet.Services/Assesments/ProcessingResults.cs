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

            classModel.Subjects = currentResults.GroupBy(pr => pr.Subject)
                                                .Select(ts => ts.Key);             

            foreach (var subject in classModel.Subjects)
            {
                var currentSubjectResult = currentResults.Where(cr => cr.Subject == subject)
                                          .Select(s => new { s.UserId, s.Progress, s.Difficulty })
                                          .GroupBy(s => s.UserId).Select(group => 
                                              new { UserId = group.Key, AverageResult = group.Average(el => el.Progress * el.Difficulty.ConvertToDouble())})
                                          .ToList();

                foreach (var userResult in currentSubjectResult)
                {
                    var existingUser = classModel.StudentsModel.FirstOrDefault(sm => sm.Id == userResult.UserId);
                    if (existingUser == null)
                    {
                        existingUser = new StudentModel(userResult.UserId) { Subjects = classModel.Subjects.Select(s => new SubjectModel(s,0.0)).ToList() };
                        classModel.StudentsModel.Add(existingUser);
                    }
                    existingUser.Subjects.First(s => s.Subject == subject).Result = userResult.AverageResult;
                }
            }

            FillPreviousResult(classModel, workResults, dateTime);
            
            return classModel;
        }
      

        private void FillPreviousResult(ClassModel classModel, TotalResult workResults, DateTimeOffset currentDateTime)
        {
            foreach(var student in classModel.StudentsModel)
            {
                foreach (var subject in student.Subjects)
                {
                    var previousSubjectUserDay = workResults.ExcercisesResults.Where(wr => wr.SubmitDateTime.DayOfYear < currentDateTime.DayOfYear
                                                        && wr.Subject == subject.Subject
                                                        && wr.UserId == student.Id)
                                                        .OrderByDescending(wr => wr.SubmitDateTime).Select(wr => wr.SubmitDateTime)
                                                        .FirstOrDefault();
                    
                    var previousSubjectUserResult = workResults.ExcercisesResults
                            .Where(wr => wr.SubmitDateTime.DayOfYear == previousSubjectUserDay.DayOfYear
                            && wr.Subject == subject.Subject && wr.UserId == student.Id);

                    var averagePreviousSubjectUserResult = 0.0;
                    if(previousSubjectUserResult.Count() > 0)
                        averagePreviousSubjectUserResult = previousSubjectUserResult.Average(cr => cr.Progress * cr.Difficulty.ConvertToDouble());
                    
                    subject.Result = Math.Round(subject.Result - averagePreviousSubjectUserResult/ Math.Abs(averagePreviousSubjectUserResult), 0);
                }
            }     
        }
    }
}
