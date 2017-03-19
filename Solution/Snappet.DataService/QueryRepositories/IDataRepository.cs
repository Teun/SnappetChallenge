using System.Collections.Generic;
using Snappet.Data.DataObjects;

namespace Snappet.Data.QueryRepositories
{
    public interface IDataRepository
    {
        IEnumerable<JsonData> GetDataFromJson(string fileName);
    }
}