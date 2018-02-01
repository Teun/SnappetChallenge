using SnappetChallenge.Core.Models;

namespace SnappetChallenge.Core
{
    public interface IUsersProvider
    {
        User[] GetUsers(SubmittedAnswersFilter filter);
    }
}