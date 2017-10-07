using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snappet.Challenge.Models;
using Snappet.Model;

namespace Snappet.Challenge.Facade
{
    public class ScatterPlotDataFacade : IScatterPlotDataFacade
    {
        public IEnumerable<KeyValuePair<double, double>> GenerateScatterPlotData(IEnumerable<StudentSkill> skills, string subject)
        {
            var dataSample= MungeData(skills, subject);
            return BuildScatterPlotterDate(dataSample);
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
                                    Count = sample.Count(iscountexist => iscountexist.Correct == true),
                                    AverageDifficulty = sample.Average(p => p.Difficulty == "NULL" ? 0 : Convert.ToDouble(p.Difficulty))
                                });
            return result;
        }

        private IEnumerable<KeyValuePair<double,double>> BuildScatterPlotterDate(IEnumerable<DataSample> dataSample)
        {

            var scatterPoints = dataSample.Select(p =>
             {
                 return new KeyValuePair<double, double>(p.AverageDifficulty, p.Count);
             });

            return scatterPoints;
        }
    }
}