using System.Collections.Generic;

namespace Snappet.Web.Helpers
{
    public class StorageProcedure
    {
        public string Name { get; set; }
        public IEnumerable<StorageProcedureParameter> Parameters { get; set; } = new List<StorageProcedureParameter>();
    }
}