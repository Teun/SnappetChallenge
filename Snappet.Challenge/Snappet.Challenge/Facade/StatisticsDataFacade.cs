using System.Collections.Generic;
using System.Linq;
using Snappet.Challenge.Models;
using Snappet.Model;
using Snappet.Challenge.Helpers;
using Snappet.DataAnalytics;

namespace Snappet.Challenge.Facade
{
    public class StatisticsDataFacade : IStatisticsDataFacade
    {
        private IDataAnalyticsFacade _dataAnalysticsFacade;
        public StatisticsDataFacade(IDataAnalyticsFacade dataAnalysticsFacade)
        {
            _dataAnalysticsFacade = dataAnalysticsFacade;
        }
        public DataPoint GenerateBellCurveData(IEnumerable<StudentSkill> skills, string subject)
        {
            var firstIteration = MungeData(skills, subject);
            var mean = CalculateMean(firstIteration);
            var deviation = FindStandardDeviation(firstIteration);
            var dataSummary = GetSummarizedData(firstIteration);
            var dataSamples = _dataAnalysticsFacade.GenerateProbabilityDensitySample(dataSummary, mean, deviation);
            return new DataPoint
            {
                Data = dataSummary,
                Distribution = dataSamples
            };
        }

        private IEnumerable<DataSample> MungeData(IEnumerable<StudentSkill> skills, string subject)
        {
            var result = skills
                                .Where(skill => {
                                    if (subject == "All")
                                    {
                                        return skill.Subject == skill.Subject;
                                    }
                                    return skill.Subject == subject;
                                })
                                .GroupBy(user => user.UserId)
                                .Select(sample => new DataSample
                                {
                                    UserId = sample.First().UserId,
                                    Count = sample.Count(iscountexist => iscountexist.Correct == true)
                                });
            return result;
        }
        private double CalculateMean(IEnumerable<DataSample> samplings)
        {
            return samplings.Average(p => p.Count);
        }
        private double FindStandardDeviation(IEnumerable<DataSample> samplings)
        {
            var result = samplings.Select(p => (double)p.Count);
            return result.StdDevOfSample();
        }
        private IEnumerable<double> GetSummarizedData(IEnumerable<DataSample> samplings)
        {
            return samplings.Select(p => (double)p.Count);
        }
    }
}