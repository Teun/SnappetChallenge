using System.Collections.Generic;
using Snappet.Data.DataObjects;
using Snappet.Website.Models;

namespace Snappet.Website.Mappers
{
    public interface ITableViewModelMapper
    {
        TableViewModel CreateTableViewModel(string title, IList<ClassResultRow> tableRows);
    }
}