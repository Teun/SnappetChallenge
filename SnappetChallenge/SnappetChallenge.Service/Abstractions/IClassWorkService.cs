using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnappetChallenge.Service.Abstractions
{
    public interface IClassWorkService
    {
        Task<IEnumerable<Work>> RetrieveClassWork(DateTime from, DateTime to);
        Task<IEnumerable<int>> RetrieveStudentsIds();
    }
}
