using System.Collections.Generic;
using System.Linq;
using Snappet.Challenge.Web.Core.Models;

namespace Snappet.Challenge.Web.Core.ViewModel
{
    public class DetailsViewModel
    {
        public IEnumerable<Work> WorkList { get; set; }
        
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => TotalRecords > PageSize;
        public int TotalRecords { get; set; }
    }
}