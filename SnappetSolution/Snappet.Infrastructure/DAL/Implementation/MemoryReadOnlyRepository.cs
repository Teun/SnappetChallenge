using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Snappet.Infrastructure.Configuration;
using Snappet.Infrastructure.DAL.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Implementation
{
	public class MemoryReadOnlyRepository : IMemoryReadOnlyRepository
	{
		private List<SubmittedAnswerDTO> _data = new List<SubmittedAnswerDTO>();
		private Dictionary<Dimensions, IEnumerable<string>> _distinctValues = new Dictionary<Dimensions, IEnumerable<string>>();

		public IEnumerable<ReportResponse> Find(ReportRequest request)
		{
			var taskUtcNow = ApplicationConfig.SnappetUtcNow;
			var dayStart = new DateTime(request.ReportDate.Year, request.ReportDate.Month, request.ReportDate.Day, 0, 0, 0, DateTimeKind.Utc);

			return _data.Where(x => x.SubmitDateTime <= taskUtcNow && x.SubmitDateTime >= dayStart && x.SubmitDateTime < dayStart.AddDays(1))
				.ApplyFilters(request)
				.Aggregate(request);
		}

		public IEnumerable<string> GetDimensionValues(Dimensions dimensionType, string term)
		{
			return string.IsNullOrEmpty(term) ? 
				_distinctValues[dimensionType] : 
				_distinctValues[dimensionType].Where(x => x.Contains(term));
		}

		public void LoadData(string filePath)
		{
			_data.Clear();

			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			using (StreamReader sr = new StreamReader(fs))
			using (JsonTextReader reader = new JsonTextReader(sr))
			{
				while (reader.Read())
				{
					if (reader.TokenType == JsonToken.StartObject)
					{
						JObject obj = JObject.Load(reader);
						_data.Add(obj.ToObject<SubmittedAnswerDTO>());
					}
				}
			}

			PopulateDistinctValues();
		}

		private void PopulateDistinctValues()
		{
			_distinctValues.Clear();

			_distinctValues.Add(Dimensions.Correct, GetDistinctValues(x => x.Correct));
			_distinctValues.Add(Dimensions.Domain, GetDistinctValues(x => x.Domain));
			_distinctValues.Add(Dimensions.ExerciseId, GetDistinctValues(x => x.ExerciseId));
			_distinctValues.Add(Dimensions.LearningObjective, GetDistinctValues(x => x.LearningObjective));
			_distinctValues.Add(Dimensions.Subject, GetDistinctValues(x => x.Subject));
			_distinctValues.Add(Dimensions.UserId, GetDistinctValues(x => x.UserId));
		}

		private IEnumerable<string> GetDistinctValues<T>(Func<SubmittedAnswerDTO, T> columnExpr)
		{
			return _data.Select(columnExpr).Select(x => x.ToString()).Distinct().OrderBy(x => x);
		}
	}
}
