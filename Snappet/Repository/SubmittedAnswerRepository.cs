using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;

namespace Snappet.Repository
{
    public class SubmittedAnswerRepository : ISubmittedAnswerRepository
    {
        private IEnumerable<SubmittedAnswer> _submittedAnswers;

        public Task SetData(IEnumerable<SubmittedAnswer> data)
        {
            _submittedAnswers = data;
            //working with tasks just to show it will probably be an asynchronous call in the future
            return Task.CompletedTask;
        }

        public IQueryable<SubmittedAnswer> GetAll()
        {
            return _submittedAnswers.AsQueryable();
        }
    }

    public interface ISubmittedAnswerRepository
    {
        IQueryable<SubmittedAnswer> GetAll();
        Task SetData(IEnumerable<SubmittedAnswer> data);
    }
}