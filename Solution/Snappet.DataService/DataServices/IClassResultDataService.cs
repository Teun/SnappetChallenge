using System;
using System.Collections.Generic;
using Snappet.Data.DataObjects;

namespace Snappet.Data.DataServices
{
    public interface IClassResultDataService
    {
        IList<ClassResultRow> GetClassResult(DateTime utcNow);
    }
}
