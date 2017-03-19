using System.Collections.Generic;
using Snappet.Data.DataObjects;

namespace Snappet.Data.Mappers
{
    public interface IReportRowMapper
    {
        IEnumerable<ClassResultRow> MapDataToReportRow(IEnumerable<JsonData> dayResults);
    }
}