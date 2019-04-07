using System.Collections.Generic;
using System.Linq;

namespace RReporter.Application.Domain
{
    public class PupilSummary
    {
        public static PupilSummary CreateFromWorkEvents (Pupil pupil, IEnumerable<WorkEvent> workEvents) => CreateFromWorkEvents (new [] { pupil }, workEvents).FirstOrDefault () ??
            new PupilSummary
            {
            UserId = pupil.UserId,
            LearningObjectiveSummaries = new LearningObjectiveSummary[0]
            };

        public static IEnumerable<PupilSummary> CreateFromWorkEvents (IEnumerable<Pupil> pupils, IEnumerable<WorkEvent> workEvents)
        {
            return workEvents
                .GroupBy (
                    e => new { e.UserId }
                ).Join (pupils,
                    group => group.Key.UserId,
                    pupil => pupil.UserId,
                    (group, pupil) => new PupilSummary
                    {
                        UserId = pupil.UserId,
                            LearningObjectiveSummaries = LearningObjectiveSummary.CreateFromWorkEvents (group).ToArray ()
                    }
                );
        }

        public int UserId { get; private set; }

        public LearningObjectiveSummary[] LearningObjectiveSummaries { get; private set; }

    }
}