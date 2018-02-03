using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface ISubmittedAnswersProvider
    {
        SubmittedAnswer[] GetAnswers(SubmittedAnswersFilter filter);
    }
}