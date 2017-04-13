// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserReportContract.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Demo.Report.API.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClassOverviewContract
    {
        public DateTime CurrentDate { get; set; }
        public IEnumerable<SubjectDomainUserOverviewContract> Subjects { get; set; }
    }

    public class SubjectDomainUserOverviewContract
    {
        public string Subject { get; set; }
        public string Domain { get; set; }
        public IEnumerable<SubjectObjectiveUserOverviewContract> ObjectiveUserOverviews { get; set; }
    }

    public class SubjectObjectiveUserOverviewContract
    {
        public string Objective { get; set; }
        public IEnumerable<UserProgressOverviewContract> UserProgressOverviews { get; set; }
    }

    public class UserProgressOverviewContract
    {
        public long UserId { get; set; }
        public IEnumerable<ExerciseProgressOverviewContract> ExcerciseProgressOverviews { get; set; }

        public bool Star => ExcerciseProgressOverviews.Count(x => x.Correct) > 5;
    }

    public class ExerciseProgressOverviewContract
    {
        public long ExerciseId { get; set; }
        public IEnumerable<ExerciseAnswersOverviewContract> Answers { get; set; }
        public float[] SlidingAverageProgressHistory { get; set; }
        public float[] ProgressHistory { get; set; }

        public bool Warning => SlidingAverageProgressHistory.First() < 0;
        public bool Zero => SlidingAverageProgressHistory.First() == 0;
        public bool Correct => ProgressHistory.All(x => x > 0);
    }

    public class ExerciseAnswersOverviewContract
    {
        public long AnswerId { get; set; }
        public int Correct { get; set; }
        public float Progress { get; set; }
    }
}