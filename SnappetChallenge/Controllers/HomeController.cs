using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SnappetChallenge.Models;
using SnappetChallenge.Repositories;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StudentRepository studentRepo = new StudentRepository();
            List<Student> model = studentRepo.GetStudents();
            
            return View(model);
        }

        public ActionResult GetStudentResults(string id)
        {
            Int64 userId;
            if (string.IsNullOrWhiteSpace(id)) return RedirectToAction("Index");

            if (!Int64.TryParse(id, out userId)) return RedirectToAction("Index");

            WorkRepository workRepo = new WorkRepository();
            List<Subject> subjects = workRepo.GetExcercisesForStudent(userId);
            return PartialView("_StudentResults", subjects);
        }

    }
}
