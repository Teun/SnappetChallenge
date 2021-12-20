using System;
using System.Threading.Tasks;
using WorkOverviewAPI.Domain;
using WorkOverviewAPI.Repositories.Interfaces;
using WorkOverviewAPI.Services.Interfaces;

namespace WorkOverviewAPI.Services
{
    public class DayOverviewService : IDayOverviewService

    {
        IDayOverviewRepository _dayOverviewRepository;
        public DayOverviewService(IDayOverviewRepository dayOverviewRepository)
        {
            _dayOverviewRepository = dayOverviewRepository;
        }

        public DayOverview getByDate(DateTime tillDT)
        {
            return _dayOverviewRepository.getByDate(tillDT);
        }

        public DayOverview getById(int pId)
        {
            return _dayOverviewRepository.getById(pId);
        }
    }
}
