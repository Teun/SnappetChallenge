using System;
using Microsoft.AspNetCore.Mvc;
using SnappetWorkApp.Repositories;

namespace SnappetWorkApp
{
    public class StudentsController : Controller
    {
        private IStudentsRepository _studentsRepository;
        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [Route("/Date/{dateString}/Students")]
        public IActionResult Index(string dateString)
        {
            var date = DateTime.Parse(dateString);
            ViewData["Date"] = date;

            return View(_studentsRepository.GetAllStudentsForDate(date));
        }

        [Route("/Date/{dateString}/Students/{id}")]
        public IActionResult Details(string dateString, int id){

            var date = DateTime.Parse(dateString);
            ViewData["Date"] = date;

            var student = _studentsRepository.GetStudentByIdForDate(id, date); 

            if(student == null)
                return NotFound();

            return View(student);
        }
    }
}