using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.WebUI.DataService
{
    using SnappetChallenge.WebUI.Models;

    public interface IDataService
    {
        IEnumerable<StudentModel> Get(DateTime from, DateTime to);
    }
}
