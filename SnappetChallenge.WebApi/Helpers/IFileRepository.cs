using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.WebApi.Helpers
{
    public interface IFileRepository<T> where T : class
    {
        IList<T> GetByData(DateTime from, DateTime to);
    }
}
