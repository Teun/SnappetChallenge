using Snappet.Business.IManager;
using Snappet.EFDesinger;
using Snappet.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Business
{
    public class WorkManager:IWorkManager
    {
        private IWorkRepository _workRepository;
        public WorkManager(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public IQueryable<work> GetStudentWork()
        {
           try
            {
                DateTime currentDate = DateTimeOffset.Parse("2015-03-24 11:30:00").UtcDateTime;
                return _workRepository.GetAll().Where(a=>a.SubmitDateTime>=currentDate && a.Correct != null && a.Correct == true).OrderByDescending(a=>a.Progress).ThenByDescending(a=>a.Difficulty);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
