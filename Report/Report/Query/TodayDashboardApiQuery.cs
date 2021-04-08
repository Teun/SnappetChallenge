using Report.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Report.Query
{
    [DataContract]
    public class TodaySubject
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "totalAnswers")]
        public int TotalAnswers { get; set; }
    }

    [DataContract]
    public class TodayDashboard
    {
        [DataMember(Name = "date")]
        public string Date { get; private set; }

        [DataMember(Name = "totalUserNumber")]
        public int TotalUserNumber { get; private set; }

        [DataMember(Name = "totalAnswerNumber")]
        public int TotalAnswerNumber { get; private set; }

        [DataMember(Name = "averageDifficulty")]
        public float AverageDifficulty { get; private set; }

        [DataMember(Name = "mostPopularSubject")]
        public string MostPopularSubject { get; private set; }

        [DataMember(Name = "subjects")]
        public List<TodaySubject> Subjects { get; private set; }

        private TodayDashboard()
        {
        }

        public class Builder
        {
            private TodayDashboard _todayDashboard;

            public Builder()
            {
                _todayDashboard = new TodayDashboard();
            }

            public Builder WithDate(DateTime dateTime)
            {
                _todayDashboard.Date = dateTime.ToString("yyyy-MM-dd");
                return this;
            }

            public Builder WithTotalUserNumber(int count)
            {
                _todayDashboard.TotalUserNumber = count;
                return this;
            }

            public Builder WithTotalAnswerNumber(int count)
            {
                _todayDashboard.TotalAnswerNumber = count;
                return this;
            }

            public Builder WithAverageDifficulty(float difficulty)
            {
                _todayDashboard.AverageDifficulty = difficulty;
                return this;
            }

            public Builder WithMostPopularSubject(string subject)
            {
                _todayDashboard.MostPopularSubject = subject;
                return this;
            }

            public Builder WithSubjects(List<TodaySubject> subjects)
            {
                _todayDashboard.Subjects = subjects;
                return this;
            }

            public TodayDashboard Build() => _todayDashboard;
        }
    }

    public class TodayDashboardApiQuery : IApiQuery<TodayDashboard>
    {
        private readonly IDataContext _dataContext;
        private readonly IDateProvider _dateProvider;

        public TodayDashboardApiQuery(IDataContext dataContext, IDateProvider dateProvider)
        {
            _dataContext = dataContext;
            _dateProvider = dateProvider;
        }

        public async Task<ApiQueryResult<TodayDashboard>> Execute()
        {
            var now = _dateProvider.Now;

            var todayActivity = await GetTodayActivity(now);

            // I have simplified this since I have in-memory model,
            // in the case of the real db, these could be separate queries or joins on the db
            var dashboard = new TodayDashboard.Builder()
                .WithDate(now)
                .WithTotalUserNumber(todayActivity.GroupBy(x => x.UserId).Count())
                .WithTotalAnswerNumber(todayActivity.Count())
                .WithAverageDifficulty(todayActivity.Where(x => x.Progress != 0).Average(x => x.Difficulty))
                .WithMostPopularSubject(todayActivity.GroupBy(x => x.Subject).OrderBy(x => x.Key).First().Key)
                .WithSubjects(todayActivity
                    .GroupBy(x => x.Subject)
                    .Select(g => new TodaySubject { Name = g.Key, TotalAnswers = g.GroupBy(x => x.SubmittedAnswerId).Count() }).ToList())
                .Build();

            return new ApiQueryResult<TodayDashboard>(dashboard);
        }

        private async Task<IEnumerable<UserActivity>> GetTodayActivity(DateTime now)
        {
            var all = await _dataContext.Get();

            var today = all.Where(a => a.SubmittedDateTimeUtc.Date == now.Date && a.SubmittedDateTimeUtc <= now);

            return today;
        }
    }
}
