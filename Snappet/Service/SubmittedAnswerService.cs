using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Entity;
using Snappet.Repository;
using Snappet.Repository.AutoComplete;

namespace Snappet.Service
{
    public class SubmittedAnswerService : ISubmittedAnswerService
    {
        private readonly AutoCompleteRepositoryResolver _repositoryResolver;
        private readonly ISubmittedAnswerRepository _submittedAnswerRepository;

        public SubmittedAnswerService(AutoCompleteRepositoryResolver repositoryResolver,
            ISubmittedAnswerRepository submittedAnswerRepository)
        {
            _repositoryResolver = repositoryResolver;
            _submittedAnswerRepository = submittedAnswerRepository;
        }

        public async Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count, AutoCompleteType type)
        {
            if (input.Length < 2) return Array.Empty<AutoCompleteItem>();

            return await _repositoryResolver(type).AutoComplete(input, count);
        }

        public Task<ICollection<SubmittedAnswer>> GetAllForStudent(long studentId, DateTime? date)
        {
            var query = _submittedAnswerRepository.GetAll();
            query = query.Where(x => x.User.Id == studentId);

            if (date.HasValue)
                query = query.Where(x => x.SubmitDateTime.ToString("d").Equals(date.Value.ToString("d")));

            return Task.FromResult<ICollection<SubmittedAnswer>>(query.ToList());
        }

        public Task<ICollection<SubmittedAnswer>> GetAll(DateTime? date)
        {
            var query = _submittedAnswerRepository.GetAll();

            if (date.HasValue)
                query = query.Where(x => x.SubmitDateTime.ToString("d").Equals(date.Value.ToString("d")));

            return Task.FromResult<ICollection<SubmittedAnswer>>(query.ToList());
        }
    }

    public interface ISubmittedAnswerService
    {
        Task<ICollection<AutoCompleteItem>> AutoComplete(string input, int count, AutoCompleteType type);
        Task<ICollection<SubmittedAnswer>> GetAll(DateTime? date);
        Task<ICollection<SubmittedAnswer>> GetAllForStudent(long studentId, DateTime? date);
    }
}