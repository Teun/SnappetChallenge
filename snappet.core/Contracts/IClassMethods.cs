using System;
using System.Collections.Generic;
using snappet.core.Models.ViewModels;

namespace snappet.core.Contracts
{
    public interface IClassMethods
    {
        List<SubjectVM> GetAvailableSubjects();
        List<string> GetAvailableDates();
        List<SubmittedAnswerVM> GetDayReportBySubject(int SubjectID, DateTime date, DateTime? startDate);
        List<SubmittedAnswerVM> GetWeekReportBySubject(int SubjectID, int Weeks);
        List<LearningObjectiveVM> GetDayReportByLO(DateTime date, DateTime? startDate);
        List<LearningObjectiveVM> GetWeekReportByLO(int Weeks);
       
    }
}