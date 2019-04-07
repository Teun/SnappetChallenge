using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RReporter.Application.Domain;
using RReporter.Application.ReportWorkSummary.Depends;
using RReporter.Application.ReportWorkSummary.Dto;

namespace RReporter.Application.ReportWorkSummary
{

    public class WorkSummaryQueries : IWorkSummaryQueries
    {
        private readonly IGetDayWorkEventsForPupil dayWorkEventsForPupil;
        private readonly IGetPupilsInClass pupilsInClass;

        public WorkSummaryQueries (IGetDayWorkEventsForPupil dayWorkEventsForPupil, IGetPupilsInClass getPupilsInClass)
        {
            this.dayWorkEventsForPupil = dayWorkEventsForPupil;
            this.pupilsInClass = getPupilsInClass;
        }

        public async Task<WorkSummaryDto> GetDaySummaryAtTimeAsync (int classId, DateTime now)
        {
            var pupils = await pupilsInClass.GetPupilsInClassAsync (classId);

            IEnumerable<Task<PupilSummary>> tasksToAwait =
                pupils.Select (async p =>
                {
                    var workEvents = await dayWorkEventsForPupil.GetDayWorkEventsForPupilAsync (p.UserId, now);
                    return PupilSummary.CreateFromWorkEvents (p, workEvents);
                });

            PupilSummary[] summaries = await Task.WhenAll (tasksToAwait);
            var workSummary = WorkSummary.Create (now, summaries);
            return workSummary.MapToDto ();
        }

    }
}