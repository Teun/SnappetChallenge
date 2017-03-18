using Snappet.Borisov.Test.Domain;

namespace Snappet.Borisov.Test.Infrastructure
{
    public interface IConvertSubmittedAnswers
    {
        SubmittedAnswer ConvertFrom(SubmittedAnswerModel model);
    }
}