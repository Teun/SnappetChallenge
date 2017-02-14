using System.Linq;
using SnappetChallenge.DataAccessLayer.DTO;

namespace SnappetChallenge.DataAccessLayer.Interfaces
{
    public interface ISubmittedAnswerRepository
    {
        IQueryable<SubmittedAnswerDto> GetAll();
        IQueryable<SubmittedAnswerDto> GetAll(int limit);
    }
}