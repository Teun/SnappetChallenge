using Snappet.GraphQL.API.DbContext;
using Snappet.GraphQL.API.Model;

namespace Snappet.GraphQL.API.Service
{
    public class SubmittedAnswersService : ISubmittedAnswersService 
    {
        private IDynamoDbContext<SubmittedAnswers> _submittedAnswersContext;

        public SubmittedAnswersService(IDynamoDbContext<SubmittedAnswers> submittedAnswersContext)
        {
            _submittedAnswersContext = submittedAnswersContext;
        }

        public async Task<SubmittedAnswers> GetSubmittedAnswerAsync(string id)
        {
            try
            {
                return await _submittedAnswersContext.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Amazon error in SubmittedAnswer table operation! Error: {ex}");
            }
        }

    }
}
