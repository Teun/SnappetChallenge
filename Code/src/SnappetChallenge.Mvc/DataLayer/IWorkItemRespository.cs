using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SnappetChallenge.Mvc.Models;

namespace SnappetChallenge.Mvc.DataLayer
{
    public interface IWorkItemRespository
    {
        Task<WorkItem[]> GetAll(Uri uri);
    }
}
