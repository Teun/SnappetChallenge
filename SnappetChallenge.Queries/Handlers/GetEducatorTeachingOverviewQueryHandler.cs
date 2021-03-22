using SnappetChallenge.Queries.Interfaces;
using SnappetChallenge.Queries.Responses;
using SnappetChallenge.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Queries.Handlers
{
    public class GetEducatorTeachingOverviewQueryHandler : 
		IQueryHandler<GetEducatorTeachingOverviewQuery, Task<IEnumerable<EducatorTeachingOverviewResponse>>>
    {
        private readonly IRepository _repository;

        public GetEducatorTeachingOverviewQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EducatorTeachingOverviewResponse>> Handle(GetEducatorTeachingOverviewQuery query)
        {
            var workResults = await _repository.GetWorkResults();

			// TotalReanswered calculates the number of exercises reanswered by a student.

			var linqQuery = from workResult in workResults
							where workResult.SubmitDateTime >= query.StartDateTimeUtc
								&& workResult.SubmitDateTime <= query.EndDateTimeUtc
							group workResult by workResult.Subject into subjectGrouping
							select new
							{
								Subject = subjectGrouping.Key,
								UniqueExercises = subjectGrouping.Select(x => x.ExerciseId).Distinct().Count(),
								UniqueStudents = subjectGrouping.Select(x => x.UserId).Distinct().Count(),
								TotalAnswers = subjectGrouping.Select(x => x.SubmittedAnswerId).Count(),
								AssessedSkillLevelChange = subjectGrouping.Select(x => (decimal)x.Progress).Sum(),
								TotalReanswered = (from subjectGroup in subjectGrouping
												   group subjectGroup by new { subjectGroup.UserId, subjectGroup.ExerciseId } into reanswerGrouping
												   where (reanswerGrouping.Count() - 1 > 0)
												   select new
												   {
													   reanswerGrouping.Key.UserId,
													   reanswerGrouping.Key.ExerciseId,
													   Reanswers = reanswerGrouping.Count() - 1
												   }).Sum(x => x.Reanswers)
							};

			var response = linqQuery.Select(linqQueryResult => new EducatorTeachingOverviewResponse
			{
				Subject = linqQueryResult.Subject,
				UniqueExercises = linqQueryResult.UniqueExercises,
				TotalAnswers = linqQueryResult.TotalAnswers,
				AssessedSkillLevelChange = linqQueryResult.AssessedSkillLevelChange,
				TotalReanswered = linqQueryResult.TotalReanswered,
				TotalReansweredPercentage = linqQueryResult.TotalAnswers != 0
					? (decimal?)linqQueryResult.TotalReanswered / linqQueryResult.TotalAnswers * 100
					: null
			}).ToList();

			return response;
        }
    }
}
