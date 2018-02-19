using Snappet.Infrastructure.DAL.Contract;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Snappet.Infrastructure.DAL.Implementation
{
	public static class RepositoryExtensions
	{
		public static IEnumerable<SubmittedAnswerDTO> ApplyFilters(
			this IEnumerable<SubmittedAnswerDTO> list,
			ReportRequest request)
		{
			list = list.AddFilter(request.CorrectColumn, x => x.Correct)
				.AddFilter(request.DomainColumn, x => x.Domain)
				.AddFilter(request.ExerciseIdColumn, x => x.ExerciseId)
				.AddFilter(request.LearningObjectiveColumn, x=>x.LearningObjective)
				.AddFilter(request.SubjectColumn, x => x.Subject)
				.AddFilter(request.UserIdColumn, x => x.UserId);

			return list;
		}

		public static IEnumerable<ReportResponse> Aggregate(this IEnumerable<SubmittedAnswerDTO> list, ReportRequest request)
		{
			return list.GroupBy(g => new
			{
				Correct = request.CorrectColumn.IsActive ? g.Correct : null,
				Domain = request.DomainColumn.IsActive ? g.Domain : null,
				ExerciseId = request.ExerciseIdColumn.IsActive ? g.ExerciseId : null,
				LearningObjective = request.LearningObjectiveColumn.IsActive ? g.LearningObjective : null,
				Subject = request.SubjectColumn.IsActive ? g.Subject : null,
				UserId = request.UserIdColumn.IsActive ? g.UserId : null
			}).Select(x => new ReportResponse()
			{
				Correct = x.Key.Correct,
				Domain = x.Key.Domain,
				ExerciseId = x.Key.ExerciseId,
				LearningObjective = x.Key.LearningObjective,
				Subject = x.Key.Subject,
				UserId = x.Key.UserId,
				DifficultyAvg = x.Average(v => v.Difficulty),
				ProgressSum = x.Sum(v => v.Progress),
				ExcercisesTotal = x.Select(y => y.ExerciseId).Distinct().Count(),
				CorrectRate = x.Where(y => y.Correct == 1).Count() / (decimal)x.Where(y => y.Correct.HasValue).Count()
			});
		}

		private static IEnumerable<SubmittedAnswerDTO>  AddFilter<T, T1>(
			this IEnumerable<SubmittedAnswerDTO> list,
			RequestColumnSettings<T> columnSettings,
			Func<SubmittedAnswerDTO, T1> column)
		{
			if (columnSettings.IsActive && columnSettings.Filter?.Any() == true )
			{
				list = list.Where(x => columnSettings.Filter.Any(f => f.Equals(column(x))));
			}

			return list;
		}
	}
}
