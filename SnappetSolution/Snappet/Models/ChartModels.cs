using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snappet.Models
{
    public class Chart
    {
        public List<ChartItem> ChartItems { get; set; }
    }

    public class ChartItem
    {
        [JsonProperty(PropertyName = "name")]
        public string AggregateLabel { get; set; }
        public List<Dataset> Datasets { get; set; }
    }

    public class Dataset
    {
        [JsonProperty(PropertyName = "prop")]
        public string AggragateBy { get; set; }
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
    }

    public class GroupByItem
    {
        public string AggregateBy { get; set; }
        public Aggregate[] Aggregates { get; set; }
    }


    public class GroupByItemOneAgg
    {
        public string AggregateBy { get; set; }
        public string Label { get; set; }
        public int Value { get; set; }
    }

    public class Aggregate
    {
        public string Label { get; set; }
        public int Value { get; set; }
    }
}