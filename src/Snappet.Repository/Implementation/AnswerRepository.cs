using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snappet.Model;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Data.Contexts;

namespace Snappet.Repository.Implementation
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AnswerContext answerContext;

        public AnswerRepository(AnswerContext AnswerContext)
        {
            this.answerContext = AnswerContext;
        }

        public void Configure(IServiceCollection services)
        {
            throw new NotImplementedException();
        }

        public void Add(Answer item)
        {
            throw new NotImplementedException();
        }

        public Answer Find(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Answer item)
        {
            throw new NotImplementedException();
        }
    }
}
