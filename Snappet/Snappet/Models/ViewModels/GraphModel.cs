using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snappet.Models.ViewModels
{
    public class GraphModel
    {
        public IEnumerable<int> UserIds { get; set; }

        public string SubjectJson { get; set; }

        public string AveragesJson { get; set; }
    }
}