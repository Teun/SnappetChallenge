using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SnappetChallenge.DAL.Entities;
using SnappetChallenge.Services.Interfaces;

namespace SnappetChallenge.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        public List<Answer> Get(Expression<Func<Answer, bool>> whereClause)
        {
            throw new NotImplementedException();
        }
    }
}
