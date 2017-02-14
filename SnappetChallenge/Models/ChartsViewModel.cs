using System;
using Chart.Mvc.ComplexChart;
using Chart.Mvc.SimpleChart;

namespace SnappetChallenge.Models
{
    public class ChartsViewModel
    {
        public BarChart ProgressBySubjectChart { get; set; }
        public DoughnutChart CorrectAnswerAmountChart { get; set; }
        public BarChart CorrectAnswersByDomainsChart { get; set; }
    }
}