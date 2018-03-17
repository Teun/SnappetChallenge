using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.Models;

namespace Snappet.Services
{
    public static class ChartService
    {
        public static IList<GroupByItem> GetCorrectnessBySub(this IList<WorkResult> workResults)
        {
            return GetCorrectnessBy(workResults, g => g.Subject);
        }

        public static IList<GroupByItem> GetCorrectnessByDomain(this IList<WorkResult> workResults)
        {
            return GetCorrectnessBy(workResults, g => g.Domain);
        }

        public static IList<GroupByItemOneAgg> GetCorrectnessByUserId(this IList<WorkResult> workResults, string label)
        {
            var groupByItems = workResults
                .GroupBy(g => g.UserId)
                .Select(s => new GroupByItemOneAgg
                {
                    AggregateBy = s.Key.ToString(),
                    Label = label,
                    Value = s.Count(w => w.Correct >= 1)                     
                })
                .OrderBy(o => o.AggregateBy)
                .ToList();

            return groupByItems;
        }

        private static IList<GroupByItem> GetCorrectnessBy(IList<WorkResult> workResults, Func<WorkResult, string> func)
        {
            var groupByItems = workResults
                .GroupBy(func)
                .Select(s => new GroupByItem
                {
                    AggregateBy = s.Key,
                    Aggregates = new Aggregate[] 
                    {
                        new Aggregate{Label = "Correct", Value = s.Count(w => w.Correct >= 1)}, 
                        new Aggregate{Label = "Incorrect", Value = s.Count(w => w.Correct == 0)}
                    }
                })
                .OrderBy(o => o.AggregateBy)
                .ToList();

            return groupByItems;
        }

        public static Chart PopulateChart(this IList<GroupByItem> groupByItems)
        {
            var chartItems = new List<ChartItem>();
            var len = groupByItems.First().Aggregates.Length;
            for(var i = 0; i < len; i++)            
            {
                var datasets = new List<Dataset> ();
                
                foreach(var groupByItem in groupByItems)    
                {
                    var dataset = new Dataset
                    {
                        AggragateBy = groupByItem.AggregateBy,
                        Value = groupByItem.Aggregates[i].Value
                    };
                    datasets.Add(dataset);
                }
                var chartItem = new ChartItem
                {
                    AggregateLabel = groupByItems.First().Aggregates[i].Label,
                    Datasets = datasets
                };
                chartItems.Add(chartItem);
            }
            
            return new Chart { ChartItems = chartItems };
        }

        public static Chart PopulateChart(this IList<GroupByItemOneAgg>[] listOfGroupByItems)
        {
            var chartItems = new List<ChartItem>();
            foreach(var groupByItems in listOfGroupByItems)
            {
                var datasets = new List<Dataset>();
                foreach (var groupByItem in groupByItems)
                {
                    var dataset = new Dataset
                    {
                        AggragateBy = groupByItem.AggregateBy,
                        Value = groupByItem.Value
                    };
                    datasets.Add(dataset);
                }
                var chartItem = new ChartItem
                {
                    AggregateLabel = groupByItems.First().Label,
                    Datasets = datasets
                };

                chartItems.Add(chartItem);
            }

            return new Chart { ChartItems = chartItems };;
        }
    }
}