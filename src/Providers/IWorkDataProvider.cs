using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Providers
{
    public interface IWorkDataProvider
    {
        Task<IEnumerable<WorkData>> GetDefaultWorkData();
    }
}
