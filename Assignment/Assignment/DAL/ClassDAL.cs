#region Imports
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assignment.Models;
using Assignment.ViewModel;
#endregion

#region namespace
namespace Assignment.DAL
{
    #region class
    public class ClassDAL
    {
        #region class
        public ClassDataViewModel ClassData (List<JsonDataModel> jsonData )
    {

        var currentdatetime = "2015-03-24 11:30";
        var currentdate = "2015-03-24";
        var objClassData = new ClassDataViewModel();
        objClassData.CurrentDateTime = currentdatetime;
        objClassData.CurrentUserIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).Select(p => p.UserId).Distinct().Count();
        objClassData.CurrentExerciseIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).Select(p => p.ExerciseId).Distinct().Count();
        objClassData.CurrentAnswerCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).Select(p => p.SubmittedAnswerId).Count();
        objClassData.CurrentCorrectCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate) && p.Correct == 1).Select(p => p.Correct).Count();
        objClassData.CurrentInCorrectCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate) && p.Correct == 0).Select(p => p.Correct).Count();
        objClassData.CurrentProgressAvg = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).Select(p => p.Progress).Average();
        objClassData.CurrentSubjectList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).OrderBy(p => p.Subject).Select(p => p.Subject).Distinct().ToList();
        objClassData.CurrentDomainList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).OrderBy(p => p.Domain).Select(p => p.Domain).Distinct().ToList(); ;
        objClassData.CurrentLearningObjectiveList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate)).OrderBy(p => p.LearningObjective).Select(p => p.LearningObjective).Distinct().ToList(); ;
        objClassData.WeeklyUserIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).Select(p => p.UserId).Distinct().Count();
        objClassData.WeeklyExerciseIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).Select(p => p.ExerciseId).Distinct().Count();
        objClassData.WeeklyAnswerCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).Select(p => p.SubmittedAnswerId).Count();
        objClassData.WeeklyCorrectCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7) && p.Correct == 1).Select(p => p.Correct).Count();
        objClassData.WeeklyInCorrectCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7) && p.Correct == 0).Select(p => p.Correct).Count();
        objClassData.WeeklyProgressAvg = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).Select(p => p.Progress).Average();
        objClassData.WeeklySubjectList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).OrderBy(p => p.Subject).Select(p => p.Subject).Distinct().ToList();
        objClassData.WeeklyDomainList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).OrderBy(p => p.Domain).Select(p => p.Domain).Distinct().ToList(); ;
        objClassData.WeeklyLearningObjectiveList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddDays(-7)).OrderBy(p => p.LearningObjective).Select(p => p.LearningObjective).Distinct().ToList(); ;
        objClassData.MonthlyUserIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).Select(p => p.UserId).Distinct().Count();
        objClassData.MonthlyExerciseIdCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).Select(p => p.ExerciseId).Distinct().Count();
        objClassData.MonthlyAnswerCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).Select(p => p.SubmittedAnswerId).Count();
        objClassData.MonthlyCorrectCount= jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1) && p.Correct == 1).Select(p => p.Correct).Count();
        objClassData.MonthlyInCorrectCount = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1) && p.Correct == 0).Select(p => p.Correct).Count();
        objClassData.MonthlyProgressAvg = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-7)).Select(p => p.Progress).Average();
        objClassData.MonthlySubjectList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).OrderBy(p => p.Subject).Select(p => p.Subject).Distinct().ToList();
        objClassData.MonthlyDomainList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).OrderBy(p => p.Domain).Select(p => p.Domain).Distinct().ToList(); ;
        objClassData.MonthlyLearningObjectiveList = jsonData.Where(p => Convert.ToDateTime(p.SubmitDateTime) < Convert.ToDateTime(currentdatetime) && Convert.ToDateTime(p.SubmitDateTime) > Convert.ToDateTime(currentdate).AddMonths(-1)).OrderBy(p => p.LearningObjective).Select(p => p.LearningObjective).Distinct().ToList();
       return objClassData;
    }
        #endregion
    }
    #endregion
}
#endregion