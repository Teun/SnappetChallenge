using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOverviewAPI.Domain;

namespace WorkOverviewAPI.Repositories.Interfaces
{
    public interface IDayOverviewRepository
    {
        DayOverview getById(int id);
        DayOverview getByDate(DateTime tillDT);
        DayOverview getBySubjectByDate(DateTime tillDT);
        Task<IEnumerable<DayOverview>> getByMonth(int year, int month);

    }
}
