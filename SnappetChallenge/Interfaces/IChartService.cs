using System.Collections.Generic;
using Chart.Mvc.ComplexChart;
using Chart.Mvc.SimpleChart;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;

namespace SnappetChallenge.Interfaces
{
    public interface IChartService
    {
        BarChart GenerateProgressBySubjectChart(List<SubmittedAnswer> submittedAnswers);
        DoughnutChart GenerateCorrectAnswerAmountChart(List<SubmittedAnswer> submittedAnswers);
        BarChart GenerateCorrectAnswersByDomainsChart(List<SubmittedAnswer> submittedAnswers);
    }
}