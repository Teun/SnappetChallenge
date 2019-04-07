using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RReporter.Application.Domain;
using RReporter.Application.ReportWorkSummary.Depends;
using RReporter.Application.StoreWorkEvent.Depends;

namespace RReporter.Framework
{
    public class MemoryWorkEventStorage : IStoreWorkEvents, IGetDayWorkEventsForPupil
    {
        private Dictionary<int, WorkEvent> _store = new Dictionary<int, WorkEvent> ();
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim ();

        public Task StoreAsync (WorkEvent workEvent)
        {
            _lock.EnterWriteLock ();
            try
            {
                _store[workEvent.SubmittedAnswerId] = workEvent;
                return Task.CompletedTask;
            }
            finally
            {
                _lock.ExitWriteLock ();
            }
        }

        public Task<IEnumerable<WorkEvent>> GetDayWorkEventsForPupilAsync (int userId, DateTime now)
        {
            _lock.EnterReadLock ();
            try
            {
                var day = now.Date; // NOTE: no time zone awareness
                IEnumerable<WorkEvent> result =
                    _store.Values
                    .Where (e => e.UserId == userId && e.SubmitDateTime > day && e.SubmitDateTime <= now)
                    .ToList ();
                return Task.FromResult (result);
            }
            finally
            {
                _lock.ExitReadLock ();
            }
        }
    }
}