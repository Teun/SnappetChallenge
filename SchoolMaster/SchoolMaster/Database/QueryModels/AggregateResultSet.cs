using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMaster.Database.QueryModels
{
    public class AggregateResultSet<TName, TValue>
    {
        public TName Name { get; set; }
        public TValue Value { get; set; }
    }

    public class AggregateResultSet<TValue>
    {
        public string Name { get; set; }
        public TValue Value { get; set; }
    }
}
