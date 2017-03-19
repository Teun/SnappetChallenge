using System.Collections.Generic;
using System.Linq;

namespace Snappet.Website.Models
{
    public class TableViewModel
    {
        public string Title { get; set; }

        public List<string> TableHeaders { get; } = new List<string>();

        public bool ShowHeader => TableHeaders.Any();

        public List<TableRowViewModel> Rows { get; } = new List<TableRowViewModel>();

    }
}