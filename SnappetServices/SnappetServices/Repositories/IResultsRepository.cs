using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Repositories
{
    public interface IResultsRepository
    {
        List<Result> GetAllResults(string date = null);
    }
}
