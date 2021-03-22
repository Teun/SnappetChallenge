using SnappetChallenge.Queries.Interfaces;
using SnappetChallenge.Queries.Responses;
using SnappetChallenge.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Queries.Handlers
{
    public class GetEducatorSubjectOverviewQueryHandler : 
		IQueryHandler<GetEducatorSubjectOverviewQuery, Task<IEnumerable<EducatorSubjectOverviewResponse>>>
    {
		private readonly IRepository _repository;

		public GetEducatorSubjectOverviewQueryHandler(IRepository repository)
        {
			_repository = repository;
		}

		public async Task<IEnumerable<EducatorSubjectOverviewResponse>> Handle(GetEducatorSubjectOverviewQuery query)
		{
			var workResults = await _repository.GetWorkResults();

			var linqQuery = from workResult in workResults
							where workResult.Subject == query.Subject
								&& workResult.SubmitDateTime >= query.StartDateTimeUtc
								&& workResult.SubmitDateTime <= query.EndDateTimeUtc
							group workResult by new
							{
								workResult.Subject,
								workResult.Domain,
								workResult.LearningObjective,
								workResult.UserId
							} into grp
							select new EducatorSubjectOverviewResponse
							{
								Domain = grp.Key.Domain,
								LearningObjective = grp.Key.LearningObjective,
								UserId = grp.Key.UserId,
								AssessedSkillLevelChange = grp.Select(x => (decimal?)x.Progress).Sum()
							};

			var response = linqQuery.ToList();
			return response;
		}
	}
}
