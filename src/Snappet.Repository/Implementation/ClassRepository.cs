using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Model;
using Snappet.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Snappet.Repository.Implementation
{
    public class ClassRepository : IClassRepository
    {
        private readonly AnswerContext answerContext;

        public ClassRepository(AnswerContext AnswerContext)
        {
            this.answerContext = AnswerContext;
        }

        public async Task<List<Class>> List()
        {
            var classes = await answerContext.Answers
                .GroupBy(a => new { a.Subject, a.Domain, a.LearningObjective })
                .Select(a => new Class() { Subject = a.Key.Subject, Domain = a.Key.Domain, LearningObjective = a.Key.LearningObjective })
                .ToListAsync();

            return classes;
        }

        public void Save()
        {
            throw new NotImplementedException("");
        }
    }
}
