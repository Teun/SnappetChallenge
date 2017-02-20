using System;

namespace Snappet.Test.TopStudents.Interface.Events
{
    public interface IMonthSubjectRankingChangedEvent
    {
        string Subject { get; set; }
        DateTime Date { get; set; }
    }
}