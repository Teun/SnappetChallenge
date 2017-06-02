using System;
using SnappetChallenge.DAL.Data;

namespace SnappetChallenge.DAL.Services.Contracts
{
    public interface IChartService
    {
        ChartData CreateDifficultyChart(DateTime fromDate, DateTime toDate);
    }
}