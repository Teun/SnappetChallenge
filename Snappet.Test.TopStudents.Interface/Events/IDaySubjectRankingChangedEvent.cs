using System;

namespace Snappet.Test.TopStudents.Interface.Events
{
    public interface IDaySubjectRankingChangedEvent
    {
        string Subject { get; set; }
        DateTime Date { get; set; }
    }
}