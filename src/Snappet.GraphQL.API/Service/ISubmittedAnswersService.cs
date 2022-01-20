namespace Snappet.GraphQL.API.Service
{
    public interface ISubmittedAnswersService
    {
        Task GetSubmittedAnswerAsync(string id);
    }
}