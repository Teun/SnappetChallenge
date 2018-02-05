using System;
using System.Collections.Generic;
using snappet.core.Models.ViewModels;

namespace snappet.core.Contracts
{
    public interface IClassMethods
    {
        List<DateTime> GetAvailableDates();
        List<LearningObjectiveVM> GetClassReport(DateTime date, DateTime? startDate);
        List<LearningObjectiveVM> GetWeekReport(int Weeks);
    }
}