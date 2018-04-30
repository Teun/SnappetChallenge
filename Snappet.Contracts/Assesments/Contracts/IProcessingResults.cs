using Snappet.Contracts.Assesments.Models;
using Snappet.Contracts.Assesments.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snappet.Contracts.Assesments.Contracts
{
    public interface IResultsProcessor
    {
        ClassModel GetProgress(TotalResult workResults, DateTimeOffset dateTime, PeriodType periodType = PeriodType.PreviousLesson);
    }
}
