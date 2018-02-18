using Snappet.Challenge.Models;
using System;
using System.Collections.Generic;

namespace Snappet.Challenge.Infrastructure
{
    public interface IWorkService
    {
        bool IsDataAvailable();
        IEnumerable<DateTime> GetDateList();
        WorkQueryLists GetWorkQueryLists(DateTime date, int offset);
        WorkSearchResults Search(WorkQuery query);
    }
}
