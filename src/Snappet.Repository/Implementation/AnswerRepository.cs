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
    public class AnswerRepository : BasicRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(SnappetContext SnappetContext)
            : base(SnappetContext, SnappetContext.Answers)
        {

        }
    }
}
