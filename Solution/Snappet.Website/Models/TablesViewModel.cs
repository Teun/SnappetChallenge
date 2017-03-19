using System.Collections.Generic;

namespace Snappet.Website.Models
{
    public class TablesViewModel
    {
        public TablesViewModel(params TableViewModel[] tables)
        {
            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
        public IList<TableViewModel> Tables { get; } = new List<TableViewModel>();
    }
}