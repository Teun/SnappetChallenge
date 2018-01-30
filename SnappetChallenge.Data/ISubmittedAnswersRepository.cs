using System.Linq;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public interface ISubmittedAnswersRepository
    {
        IQueryable<SubmittedAnswerDb> Query();
    }
}