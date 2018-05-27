using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Core;
using SnappetChallenge.Models;
using SnappetChallenge.Repositories;

namespace SnappetChallenge.Controllers
{
    [Route("api/[controller]")]
    public class WorkDataController : Controller
    {
        private IClock _clock;
        private IClassProgressRepository _repository;

        public WorkDataController(IClock clock, IClassProgressRepository repository)
        {
            _clock = clock;
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<LearningObjectiveViewModel> LearningObjectives(int dateIndex)
        {
            var dateFilter = CalculateDateFilter(dateIndex);
            var objectives = await _repository.GetDailyLearningObjectiveProgressAsync(dateFilter);
            var model = new LearningObjectiveViewModel
            {
                Date = dateFilter,
                Objectives = objectives
            };

            model.Domains = objectives
                .GroupBy(x => x.Domain)
                .OrderBy(x=> x.Key)
                .Select(x => new ChartData<string, int>
            {
                XAxis = x.Key,
                YAxis = x.Sum(y => y.TotalProgress)
            });

            return model;
        }

        [HttpGet("[action]")]
        public async Task<StudentViewModel> StudentsProgress(int dateIndex, string learningObjective)
        {
            var dateFilter = CalculateDateFilter(dateIndex);
            var students = await _repository.GetDailyStudentsProgressAsync(dateFilter, learningObjective);

            return new StudentViewModel
            {
                Date = dateFilter,
                LearningObjective = learningObjective,
                Students = students
            };
        }

        private DateTime CalculateDateFilter(int dateIndex)
        {
            DateTime dateFilter = _clock.Now;
            dateFilter = dateIndex < 0 ? dateFilter.Date.AddDays(dateIndex).AddTicks(TimeSpan.TicksPerDay - 1) : dateFilter;

            return dateFilter;
        }
    }
}
