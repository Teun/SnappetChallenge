using SnappetServices.DTOs;
using SnappetServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetServices.Services
{
    public interface IResultsServices
    {
        IEnumerable<ResultV1Dto> GetAllResults(DateTime date);
    }
}
