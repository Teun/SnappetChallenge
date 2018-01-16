using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.WebAPI.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}