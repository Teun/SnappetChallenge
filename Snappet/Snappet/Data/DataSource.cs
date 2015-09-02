using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Snappet.Utility;

namespace Snappet.Data
{
	public class DataSource
	{
		private static readonly Answer[] AnswersData;

		public static DateTime CutOffDateTime = new DateTime(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

		static DataSource()
		{
			var dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
			var filePath = Path.Combine(dataPath, "work.json");
			var tmpData = LoadData(filePath);

			// Dates from the future does not exist yet!
			AnswersData = tmpData.Where(a => a.SubmitDateTime <= CutOffDateTime).ToArray();
		}

		private static Answer[] LoadData(string fileName)
		{
			Answer[] ansArr;

			using (var sr = File.OpenText(fileName))
			using (var reader = new JsonTextReader(sr))
			{
				var serializer = new JsonSerializer()
				{
					DateTimeZoneHandling = DateTimeZoneHandling.Utc
				};
				ansArr = serializer.Deserialize<Answer[]>(reader);
			}

			return ansArr;
		}

		public AnswersPerDay[] GetAnswersPerDay(string timeZone, DateTime today)
		{
			var res = AnswersData.Where(d => d.SubmitDateTime.UtcToZoned(timeZone).Date > today.Date.AddDays(-30)
			                                 && d.SubmitDateTime.UtcToZoned(timeZone).Date <= today)
				.GroupBy(a => new {a.Subject, a.SubmitDateTime.UtcToZoned(timeZone).Date})
				.Select(grp =>
					new AnswersPerDay
					{
						Subject = grp.Key.Subject,
						Date = grp.Key.Date,
						Count = grp.Count()
					});

			return res.ToArray();
		}

		public ObjectiveAndCount[] GetTopObjectivePerSubjectForADay(string subject, DateTime day, string timeZone, int limit)
		{
			day = day.UtcToZoned(timeZone).Date;
			var res = AnswersData.Where(a => a.Subject.Equals(subject, StringComparison.InvariantCultureIgnoreCase)
			                                 && a.SubmitDateTime.UtcToZoned(timeZone).Date == day)
				.GroupBy(a => a.LearningObjective)
				.Select(grp =>
					new ObjectiveAndCount
					{
						Name = grp.Key,
						Count = grp.Count()
					})
				.OrderByDescending(o => o.Count)
				.Take(limit);

			return res.ToArray();
		}

		public ObjectiveAndCount[] GetLowestObjectivePerSubjectForADay(string subject, DateTime day, string timeZone,
			int limit)
		{
			day = day.UtcToZoned(timeZone).Date;
			var res = AnswersData.Where(a => a.Subject.Equals(subject, StringComparison.InvariantCultureIgnoreCase)
			                                 && a.SubmitDateTime.UtcToZoned(timeZone).Date == day)
				.GroupBy(a => a.LearningObjective)
				.Select(grp =>
					new ObjectiveAndCount
					{
						Name = grp.Key,
						Count = grp.Count()
					})
				.OrderBy(o => o.Count)
				.Take(limit);

			return res.ToArray();
		}
	}
}