using SnappetChallenge.Infrastructure.Models;

namespace SnappetChallenge.Application.Responses
{
    public class GetWorksForDateResponse
    {
        public GetWorksForDateResponse(WorksDTO works)
        {
            Works = works;
        }

        public WorksDTO Works { get; private set; }
    }
}