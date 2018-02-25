using System.Collections.Generic;

namespace Snappet.Repository.Helpers
{

    public class QueryResult<T> where T : class
    {
        public QueryResult(IEnumerable<T> result, int totalRecords)
        {
            Result = result;
            TotalRecords = totalRecords;
        }

        public int TotalRecords { get; private set; }
        public IEnumerable<T> Result { get; private set; }
    }
}
