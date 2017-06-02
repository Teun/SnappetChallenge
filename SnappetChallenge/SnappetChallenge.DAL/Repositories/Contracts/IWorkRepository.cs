using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SnappetChallenge.DAL.Data;

namespace SnappetChallenge.DAL.Repositories.Contracts
{
    public interface IWorkRepository
    {
        IEnumerable<Work> GetByDate(DateTime fromDate, DateTime toDate);
    }
}