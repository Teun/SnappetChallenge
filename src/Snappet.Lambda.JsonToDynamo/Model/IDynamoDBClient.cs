using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snappet.Lambda.JsonToDynamo.Model
{
    public interface IDynamoDBClient
    {
        Task SaveAnswersAsync(List<SubmittedAnswers> submittedAnswers);

    }
}