using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Snappet.Challenge.Web.Core.ViewModel;
using Snappet.Challenge.Web.Repositories;

namespace Snappet.Challenge.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IClassRepository _classRepository;

        public StudentController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public IActionResult History(int id)
        {
            var studentHistory = _classRepository.GetUserWorkHistoryByObjective(id)
                .GroupBy(h => new { h.Date, h.LearningObjective })
                .Select(g => new LearningObjectiveSummaryViewModel
                {
                    StudentId = id,
                    LearningObjective = g.Key.LearningObjective,
                    Date = g.Key.Date.Value,
                    StudentCorrectAnswer = g.Sum(l => l.Correct),
                    StudentTotalAnswer = g.Sum(l => l.Total)
                }).GroupBy(l => l.Date)
                .ToDictionary(k => k.Key, v => v.ToList());            
            
            return View(studentHistory);
        }
    }
}