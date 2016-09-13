using Snappet.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snappet.Model;
using Snappet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Snappet.Repository.Implementation.Base;

namespace Snappet.Repository.Implementation
{
    public class ClassRepository : BasicRepository<Class>, IClassRepository
    {
        private readonly SnappetContext answerContext;

        public ClassRepository(SnappetContext SnappetContext)
            : base(SnappetContext, SnappetContext.Classes)
        {

        }

        public async Task<List<Class>> List()
        {
            //var classes = await answerContext.Answers
            //    .GroupBy(a => new { a.Subject, a.Domain, a.LearningObjective })
            //    .Select(a => new Class() { Subject = a.Key.Subject, Domain = a.Key.Domain, LearningObjective = a.Key.LearningObjective })
            //    .ToListAsync();

            //return classes;
            return null;
        }

        public async Task<List<String>> ListSubjects()
        {
            return null;// return await ListDistinctStrings(a => a.Subject); ;
        }

        public async Task<List<String>> ListDomains()
        {
            return null;//return await ListDistinctStrings(a => a.Domain);
        }

        public async Task<List<String>> ListLearningObjectives()
        {
            return null;//return await ListDistinctStrings(a => a.LearningObjective);
        }

        private async Task<List<string>> ListDistinctStrings(Expression<Func<Answer, string>> selectExpression)
        {
            var strings = await answerContext.Answers
                .Select(selectExpression)
                .Distinct()
                .ToListAsync();

            return strings;
        }
    }
}
