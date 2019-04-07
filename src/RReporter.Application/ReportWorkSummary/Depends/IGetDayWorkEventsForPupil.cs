using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RReporter.Application.Domain;

namespace RReporter.Application.ReportWorkSummary.Depends
{
    public interface IGetDayWorkEventsForPupil
    {
        Task<IEnumerable<WorkEvent>> GetDayWorkEventsForPupilAsync (int userId, DateTime now);
    }
}