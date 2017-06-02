using SnappetChallenge.DAL.Data;
using SnappetChallenge.DAL.Repositories.Contracts;
using SnappetChallenge.DAL.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappetChallenge.DAL.Services
{
    public class ChartService : IChartService
    {
        private IWorkRepository _workRepository;

        public ChartService(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }

        public ChartData CreateDifficultyChart(DateTime fromDate, DateTime toDate)
        {
            var chart = new ChartData();

            var labels = new List<string>();
            var avgDifficulty = new List<int>();
            var correct = new List<int>();
            var incorrect = new List<int>();

            var data = _workRepository.GetByDate(fromDate, toDate).GroupBy(w=>w.SubmitDateTime.Date);
            foreach(var daygroup in data)
            {
                foreach(var hourgroup in daygroup.GroupBy(d => d.SubmitDateTime.Hour))
                {
                    labels.Add($"{daygroup.Key.ToShortDateString()} {hourgroup.Key}h");
                    avgDifficulty.Add((int)hourgroup.Where(w=>w.Difficulty.HasValue).Average(w => w.Difficulty.Value));
                    var numCorrect = hourgroup.Count(w => w.Correct > 0);
                    correct.Add(numCorrect);
                    incorrect.Add(hourgroup.Count() - numCorrect);
                }
            }

            chart.Labels = labels;
            chart.DataSets = new Dictionary<string, IEnumerable<int>> { { "avgDiff", avgDifficulty }, {"correct",correct }, {"incorrect",incorrect } };
            return chart;
        }
    }
}
