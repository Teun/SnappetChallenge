using System;
using Microsoft.AspNetCore.Mvc;
using SnappetWorkApp.Repositories;

namespace SnappetWorkApp
{
    public class SubjectsController : Controller
    {
        private readonly IStudentsRepository _studentsRepository;

        public SubjectsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [Route("/Date/{dateString}/Students/{studentId}/Subjects/{name}")]
        public IActionResult Details(string dateString, int studentId, string name){

            var date = DateTime.Parse(dateString);
            ViewData["Date"] = date;
            ViewData["StudentId"] = studentId;

            var subjectViewModel = _studentsRepository.GetStudentSubjectForDate(studentId, name, date);

            return View(subjectViewModel);
        }
    }
}