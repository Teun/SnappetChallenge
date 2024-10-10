using ClassMonitor.Core.Interfaces;
using ClassMonitor.Core.Models;
using ClassMonitor.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassMonitor.Web.Pages
{
    public class LineChartWidgetModel(IStudentProgressService service) : PageModel
    {
        public ApexLineChartModel ChartModel { get; set; }

        public string Title { get; set; }

        public async Task OnGetDailyRelativeAsync(DateTime date)
        {
            var data = await service.GetDailyProgressByStudent(date.Year, date.Month, date.Day);
            var students = data.Select(x => x.StudentName).Distinct().ToArray();
            var xAxisValues = Enumerable.Range(0, 96).Select(x => date.Date.AddMinutes(x * 15)).ToArray();
            var completeData = data.ToList();
            foreach (var student in students)
            {
                var newData = new List<ProgressByStudent>(96);
                foreach (var xAxisValue in xAxisValues)
                {
                    newData.Add(new ProgressByStudent { DateTime = xAxisValue, Progress = null, StudentName = student });
                }

                completeData.AddRange(newData);
            }

            var seriesData = completeData
                .GroupBy(x => x.StudentName)
                .Select(x => new ApexLineChartModel.SeriesModel
                {
                    Name = x.Key,
                    Data = x.OrderBy(y => y.DateTime).GroupBy(y => y.DateTime.Hour * 60 + y.DateTime.Minute / 15).Select(y => y.Select(z => (float?)z?.Progress).Sum()).ToArray()
                });

            var unixEpoch = new DateTime(1970, 1, 1);
            ChartModel = new()
            {
                Series = seriesData.ToArray(),
                Xaxis = new ApexLineChartModel.XAxisDoubleModel() { Categories = xAxisValues.Select(x => x.Subtract(unixEpoch).TotalSeconds * 1000).ToArray() }
            };

            Title = "Daily relative progress per student";
        }

        public async Task OnGetDailyAbsoluteAsync(DateTime date)
        {
            var data = await service.GetDailyProgressByStudent(date.Year, date.Month, date.Day);
            var students = data.Select(x => x.StudentName).Distinct().ToArray();
            var xAxisValues = Enumerable.Range(0, 96).Select(x => date.Date.AddMinutes(x * 15)).ToArray();
            var completeData = data.ToList();
            foreach (var student in students)
            {
                var newData = new List<ProgressByStudent>(96);
                foreach (var xAxisValue in xAxisValues)
                {
                    newData.Add(new ProgressByStudent { DateTime = xAxisValue, Progress = null, StudentName = student });
                }

                completeData.AddRange(newData);
            }

            var seriesData = new List<ApexLineChartModel.SeriesModel>();
            foreach (var series in completeData.GroupBy(x => x.StudentName))
            {
                var dateTimeGroups = series
                    .OrderBy(y => y.DateTime)
                    .GroupBy(y => y.DateTime.Hour * 60 + y.DateTime.Minute / 15)
                    .Select(y => y.Select(z => (float?)z?.Progress).Sum())
                    .ToArray();
                for (var i = 1; i < dateTimeGroups.Length; i++)
                {
                    dateTimeGroups[i] += dateTimeGroups[i - 1];
                }

                seriesData.Add(new ApexLineChartModel.SeriesModel
                {
                    Name = series.Key,
                    Data = dateTimeGroups
                });
            }

            var unixEpoch = new DateTime(1970, 1, 1);
            ChartModel = new()
            {
                Series = seriesData.ToArray(),
                Xaxis = new ApexLineChartModel.XAxisDoubleModel() { Categories = xAxisValues.Select(x => x.Subtract(unixEpoch).TotalSeconds * 1000).ToArray() }
            };

            Title = "Daily absolute progress per student";
        }

        public async Task OnGetMonthlyRelativeAsync(DateTime date)
        {
            var data = await service.GetMonthlyProgressByStudent(date.Year, date.Month);
            var students = data.Select(x => x.StudentName).Distinct().ToArray();
            var beginningOfMonth = new DateTime(date.Year, date.Month, 1);
            var xAxisValues = Enumerable.Range(0, DateTime.DaysInMonth(date.Year, date.Month)).Select(x => beginningOfMonth.AddDays(x)).ToArray();
            var completeData = data.ToList();
            foreach (var student in students)
            {
                var newData = new List<ProgressByStudent>(31);
                foreach (var xAxisValue in xAxisValues)
                {
                    newData.Add(new ProgressByStudent { DateTime = xAxisValue, Progress = null, StudentName = student });
                }

                completeData.AddRange(newData);
            }

            var seriesData = completeData
                .GroupBy(x => x.StudentName)
                .Select(x => new ApexLineChartModel.SeriesModel
                {
                    Name = x.Key,
                    Data = x
                    .OrderBy(y => y.DateTime)
                    .GroupBy(y => y.DateTime.Day)
                    .Select(y => y.Select(z => (float?)z?.Progress).Sum())
                    .ToArray()
                });

            ChartModel = new()
            {
                Series = seriesData.ToArray(),
                Xaxis = new ApexLineChartModel.XAxisStringModel() { Categories = xAxisValues.Select(x => x.ToString("dd MMM yy")).ToArray() }
            };

            Title = "Monthly relative progress per student";
        }

        public async Task OnGetMonthlyAbsoluteAsync(DateTime date)
        {
            var data = await service.GetMonthlyProgressByStudent(date.Year, date.Month);
            var students = data.Select(x => x.StudentName).Distinct().ToArray();
            var beginningOfMonth = new DateTime(date.Year, date.Month, 1);
            var xAxisValues = Enumerable.Range(0, DateTime.DaysInMonth(date.Year, date.Month)).Select(x => beginningOfMonth.AddDays(x)).ToArray();
            var completeData = data.ToList();
            foreach (var student in students)
            {
                var newData = new List<ProgressByStudent>(31);
                foreach (var xAxisValue in xAxisValues)
                {
                    newData.Add(new ProgressByStudent { DateTime = xAxisValue, Progress = null, StudentName = student });
                }

                completeData.AddRange(newData);
            }

            var seriesData = new List<ApexLineChartModel.SeriesModel>();
            foreach (var series in completeData.GroupBy(x => x.StudentName))
            {
                var dateTimeGroups = series
                    .OrderBy(y => y.DateTime)
                    .GroupBy(y => y.DateTime.Day)
                    .Select(y => y.Select(z => (float?)z?.Progress).Sum())
                    .ToArray();
                for (var i = 1; i < dateTimeGroups.Length; i++)
                {
                    dateTimeGroups[i] += dateTimeGroups[i - 1];
                }

                seriesData.Add(new ApexLineChartModel.SeriesModel
                {
                    Name = series.Key,
                    Data = dateTimeGroups
                });
            }

            ChartModel = new()
            {
                Series = seriesData.ToArray(),
                Xaxis = new ApexLineChartModel.XAxisStringModel() { Categories = xAxisValues.Select(x => x.ToString("dd MMM yy")).ToArray() }
            };

            Title = "Monthly absolute progress per student";
        }
    }
}
