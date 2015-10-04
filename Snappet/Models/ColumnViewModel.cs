using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.Models
{
    public class ColumnViewModel
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public SearchviewModel search { get; set; }
    }
    public class SearchviewModel
    {
        public string value { get; set; }
        public bool regex { get; set; }
    }

    public class OrderViewModel
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
}