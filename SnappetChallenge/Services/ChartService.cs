using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Chart.Mvc.ComplexChart;
using Chart.Mvc.SimpleChart;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.Interfaces;

namespace SnappetChallenge.Services
{
    public class ChartService : IChartService
    {
        public BarChart GenerateProgressBySubjectChart(List<SubmittedAnswer> submittedAnswers)
        {
            var progressByMonthForCurrentYear = submittedAnswers
                .GroupBy(
                    x => x.Subject,
                    x => x,
                    (subject, answerList) => new
                    {
                        Subject = subject,
                        ProgressByMonth = (double)answerList.Sum(y => y.Progress)
                    })
                    .OrderBy(x => x.Subject)
                    .ToList();

            var progressBySubject = new BarChart();
            progressBySubject.ChartConfiguration.Animation = true;
            progressBySubject.ChartConfiguration.Responsive = true;
            progressBySubject.ChartConfiguration.MaintainAspectRatio = true;
            progressBySubject.ChartConfiguration.ScaleBeginAtZero = false;
            progressBySubject.ComplexData.Labels.AddRange(progressByMonthForCurrentYear.Select(x => x.Subject).ToList());
            progressBySubject.ComplexData.Datasets.AddRange(new List<ComplexDataset>() {
                new ComplexDataset
                {
                    Data = progressByMonthForCurrentYear.Select(x => x.ProgressByMonth).ToList(),
                    Label = "Progress by subjects",
                    FillColor = "rgba(98, 217, 217,0.2)",
                    StrokeColor = "rgba(98, 217, 217,1)",
                    PointColor = "rgba(98, 217, 217,1)",
                    PointStrokeColor = "#fff",
                    PointHighlightFill = "#fff",
                    PointHighlightStroke = "rgba(120,220,120,1)",
                    
                }
            });

            return progressBySubject;
        }

        public BarChart GenerateCorrectAnswersByDomainsChart(List<SubmittedAnswer> submittedAnswers)
        {
            var correctAnswersByDomain = submittedAnswers
                .Where(x => x.IsCorrect)
                .GroupBy(
                    x => x.Domain,
                    x => x,
                    (domain, answerList) => new
                    {
                        Domain = domain,
                        CorrectAnswerCount = (double)answerList.Count()
                    })
                    .OrderBy(x => x.Domain)
                    .ToList();

            var progressBySubject = new BarChart();
            progressBySubject.ChartConfiguration.Animation = true;
            progressBySubject.ChartConfiguration.Responsive = true;
            progressBySubject.ChartConfiguration.MaintainAspectRatio = true;
            progressBySubject.ChartConfiguration.ScaleBeginAtZero = true;
            progressBySubject.ComplexData.Labels.AddRange(correctAnswersByDomain.Select(x => x.Domain).ToList());
            progressBySubject.ComplexData.Datasets.AddRange(new List<ComplexDataset>() {
                new ComplexDataset
                {
                    Data = correctAnswersByDomain.Select(x => x.CorrectAnswerCount).ToList(),
                    Label = "Correct answers by domain",
                    FillColor = "rgba(98, 217, 158,0.2)",
                    StrokeColor = "rgba(98, 217, 158,1)",
                    PointColor = "rgba(98, 217, 158,1)",
                    PointStrokeColor = "#fff",
                    PointHighlightFill = "#fff",
                    PointHighlightStroke = "rgba(120,220,120,1)",

                }
            });

            return progressBySubject;
        }

        public DoughnutChart GenerateCorrectAnswerAmountChart(List<SubmittedAnswer> submittedAnswers)
        {
            double correctAnswersCount = submittedAnswers.Count(x => x.IsCorrect);
            double incorrectAnswersCount = submittedAnswers.Count - correctAnswersCount;

            var progressBySubject = new DoughnutChart();
            progressBySubject.ChartConfiguration.Animation = true;
            progressBySubject.ChartConfiguration.Responsive = true;
            progressBySubject.ChartConfiguration.MaintainAspectRatio = true;
            progressBySubject.ChartConfiguration.ScaleBeginAtZero = false;
            progressBySubject.Data = new List<SimpleData>()
            {
                new SimpleData()
                {
                    Color = "rgba(20,20,220,0.2)",
                    Label = "Correct answers count",
                    Value = correctAnswersCount
                },
                new SimpleData()
                {
                    Color = "rgba(220,20,20,0.2)",
                    Label = "Incorrect answers count",
                    Value = incorrectAnswersCount
                }
            };

            return progressBySubject;
        }
    }
}