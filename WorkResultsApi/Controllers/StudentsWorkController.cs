using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorkResultsApi.Models;
using System.Linq;
using WorkResultsApi.Infrastructure;
using System;

namespace WorkResultsApi.Controllers
{
    [ApiController]
    public class StudentsWorkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DateTime mockStartDate = new DateTime(2015, 03, 24, 0, 0, 0);
        private readonly DateTime mockEndDate = new DateTime(2015, 03, 24, 11, 30, 0);

        public StudentsWorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("[controller]/[Action]")]
        public IEnumerable<StudentWorkItem> GetStudentOverview(int id)
        {
            var studentWorkItems = _context.StudentWorkItems
            .Where(x => x.UserId == id &&
            mockStartDate < x.SubmitDateTime &&
            mockEndDate > x.SubmitDateTime).ToList();

            return studentWorkItems;
        }

        [HttpGet]
        [Route("[controller]/[Action]")]
        public IEnumerable<StudentWorkItem> GetExerciseOverview(int id)
        {
            var exerciseWorkItems = _context.StudentWorkItems
            .Where(x => x.ExerciseId == id &&
            mockStartDate < x.SubmitDateTime &&
            mockEndDate > x.SubmitDateTime).ToList();

            return exerciseWorkItems;
        }

        [HttpGet]
        [Route("[controller]/[Action]")]
        public IEnumerable<ExerciseItem> GetExercises()
        {
            var exercises = _context.StudentWorkItems
            .Where(x => mockStartDate < x.SubmitDateTime &&
            mockEndDate > x.SubmitDateTime).ToList();

            List<ExerciseItem> exerciseItems = new List<ExerciseItem>();

            foreach (var item in exercises.GroupBy(x => x.ExerciseId))
            {
                var exercise = item.First();

                exerciseItems.Add(new ExerciseItem
                {
                    ExerciseId = item.Key,
                    Quantity = item.Count(),
                    correctAnswers = item.Count(x => x.Correct),
                    Difficulty = exercise.Difficulty,
                    Domain = exercise.Domain,
                    Subject = exercise.Subject,
                    LearningObjective = exercise.LearningObjective,
                });
            };

            return exerciseItems;
        }
    }
}