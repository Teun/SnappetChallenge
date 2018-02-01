namespace SnappetChallenge.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using ChartJSCore.Models;

    using Microsoft.AspNetCore.Mvc.Rendering;

    using Remotion.Linq.Utilities;

    public class ChartData
    {
        private static Random Random => new Random();

        private List<LineDataset> _data = new List<LineDataset>();

        public List<string> Label { get; set; }

        public static List<SelectListItem> DateFilterItems { get; set; } = new List<SelectListItem>() { new SelectListItem() { Text = "All Dates", Value = "" } };

        public Chart Chart { get; set; }

        public List<LineDataset> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        public ChartData PrepareChartWithData(List<ClassAssignment> assignments, bool isFiltered = false)
        {
            Chart chart = new Chart();

            chart.Type = "line";

            ChartJSCore.Models.Data data = new ChartJSCore.Models.Data();
            var chartData = isFiltered ?
                GenerateAggregateForADay(assignments) :
                GenerateAggregateForEntireRange(assignments);
            data.Datasets = new List<Dataset>();
            data.Labels = chartData.Label;
            chartData.Data.ForEach(x =>
                {
                    data.Datasets.Add(x);
                });
            chart.Data = data;
            chart.Options = new Options()
            {
                Responsive = true,
            };
            Chart = chart;
            return this;
        }

        private ChartData GenerateAggregateForEntireRange(List<ClassAssignment> assignments)
        {
            var summarizedData = assignments.OrderBy(o => o.SubmitDateTime).ToLookup(x => x.SubmitDateTime.Date.ToShortDateString());
            Label = summarizedData.Select(x => x.Key).ToList();
            foreach (var dayAssignment in summarizedData)
            {
                DateFilterItems.Add(new SelectListItem() { Text = dayAssignment.Key, Value = dayAssignment.Key });
                var subjects = dayAssignment.GroupBy(d => d.Subject);
                foreach (var daySubject in subjects)
                {
                    LineDataset subjectData;
                    if ((subjectData = Data.SingleOrDefault(x => x.Label.Equals(daySubject.Key, StringComparison.OrdinalIgnoreCase))) == null)
                    {
                        subjectData = InitLineDatasetWithDefaults(daySubject.Key);
                        Data.Add(subjectData);
                        subjectData.Data = new List<double>();
                    }
                    subjectData.Data.Add(daySubject.Count());
                }
            }
            DateFilterItems.ForEach(x => x.Selected = false);
            return this;
        }

        private ChartData GenerateAggregateForADay(List<ClassAssignment> dayAssignments)
        {
            var summarizedData = dayAssignments.ToLookup(x => x.Subject);
            Label = summarizedData.Select(x => x.Key).ToList();
            var correctData = InitLineDatasetWithDefaults("Total Correct");
            var nonZeroProgress = InitLineDatasetWithDefaults("Total Real Progress");
            var nonZeroDifficulty = InitLineDatasetWithDefaults("Total Difficulty");
            var totalDistinctSubmissions = InitLineDatasetWithDefaults("Total Distinct Submissions");
            foreach (var dayData in summarizedData)
            {
                correctData.Data.Add(dayData.Count(x => x.Correct != 0));
                nonZeroProgress.Data.Add(dayData.Count(x => x.Progress > 0));
                nonZeroDifficulty.Data.Add(dayData.Count(x => x.Difficulty > 0));
                totalDistinctSubmissions.Data.Add(dayData.Select(x=>x.UserId).Distinct().Count());
            }
            Data.Add(correctData);
            Data.Add(nonZeroProgress);
            Data.Add(nonZeroDifficulty);
            Data.Add(totalDistinctSubmissions);
            return this;
        }

        private LineDataset InitLineDatasetWithDefaults(string label)
        {
            var color1 = $"#{Random.Next(0x1000000):X6}";
            var color2 = $"#{Random.Next(0x1000000):X6}";
            var chartData = new LineDataset();
            chartData.Label = label;
            chartData.Data = new List<double>();
            chartData.Fill = false;
            chartData.LineTension = 0.1;
            chartData.BackgroundColor = color1;
            chartData.BorderColor = color1;
            chartData.BorderCapStyle = "butt";
            chartData.BorderDash = new List<int> { };
            chartData.BorderDashOffset = 0.0;
            chartData.BorderJoinStyle = "miter";
            chartData.PointBorderColor = new List<string>() { color2 };
            chartData.PointBackgroundColor = new List<string>() { "#fff" };
            chartData.PointBorderWidth = new List<int> { 1 };
            chartData.PointHoverRadius = new List<int> { 5 };
            chartData.PointHoverBackgroundColor = new List<string>() { "rgba(75,192,192,1)" };
            chartData.PointHoverBorderColor = new List<string>() { "rgba(220,220,220,1)" };
            chartData.PointHoverBorderWidth = new List<int> { 2 };
            chartData.PointRadius = new List<int> { 1 };
            chartData.PointHitRadius = new List<int> { 10 };
            chartData.SpanGaps = false;
            chartData.ShowLine = true;
            return chartData;
        }
    }
}