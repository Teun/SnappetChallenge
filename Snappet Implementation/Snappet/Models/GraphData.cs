using System;
using System.Collections.Generic;

namespace Snappet.Models
{
    class GraphData<T>
    {
        public List<String> labels { get; set; }
        public List<List<T>> series { get; set; }

        public GraphData(List<String> labels, List<T> series)
        {
            this.labels = labels;
            this.series = new List<List<T>>();
            this.series.Add(series);
        }
    }
}
