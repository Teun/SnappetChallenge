using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet2.Data;
using Snappet2.ViewModel;

namespace Snappet2.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly SnappetContext _context;
        public ExerciseController(SnappetContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var excerciesResults = _context.SubmittedAnswers.Where(s => s.ExerciseId == id).
                Select(s => new UserResultViewModel { UserId = s.UserId, Correct = s.Correct }).ToList();
            return View(excerciesResults);
        }
    }
}