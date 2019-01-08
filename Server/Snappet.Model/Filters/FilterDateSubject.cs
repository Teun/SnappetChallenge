using System;
using System.Collections.Generic;

namespace Snappet.Model.Filters
{
    public class FilterDateSubject
    {
        public DateTime DateTime { get; set; }

        public List<FilterSubjectDomain> SubjectsList { get; set; }
    }
}
