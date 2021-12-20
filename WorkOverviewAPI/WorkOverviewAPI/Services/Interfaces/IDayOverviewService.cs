using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOverviewAPI.Domain;

namespace WorkOverviewAPI.Services.Interfaces
{
    public interface IDayOverviewService
    {
        DayOverview getById(int pId);
        DayOverview getByDate(DateTime tillDT);
    }
}
