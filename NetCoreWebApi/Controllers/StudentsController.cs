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

        public IActionResult Index()
        {
            var date = new DateTime(2015,3,24);

            ViewData["Date"] = date;

            return View(_studentsRepository.GetAllStudentsForDate(date));
        }

        public IActionResult Details(int id){

            var student = _studentsRepository.GetStudentByIdForDate(id, new DateTime(2015,3,24)); 

            if(student == null)
                return NotFound();

            return View(student);
        }
    }
}