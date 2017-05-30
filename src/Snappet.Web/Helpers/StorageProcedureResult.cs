using System.Collections.Generic;

namespace Snappet.Web.Helpers
{
    public class StorageProcedureResult
    {
        public List<string> Columns { get; set; } = new List<string>();
        public List<List<object>> Rows { get; set; } = new List<List<object>>();
    }
}
