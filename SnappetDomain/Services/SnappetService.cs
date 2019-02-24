using SnappetDomain.Models;
using SnappetDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetDomain.Services
{
    public class SnappetService: ISnappetService
    {
        private readonly ISnappetRepository _repository; 

        public SnappetService(ISnappetRepository repository)
        {
            _repository = repository;
        }

        public List<LearningSubject> GetByDate(DateTime maxDateTime)
            => _repository.GetLearningDataByDate(maxDateTime.ToUniversalTime()).ToList();

    }

    public interface ISnappetService
    {
        List<LearningSubject> GetByDate(DateTime maxDateTime);
    }
}
