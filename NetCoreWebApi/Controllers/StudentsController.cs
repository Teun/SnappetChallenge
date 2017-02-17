using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnappetWorkApp.Services;

namespace SnappetWorkApp
{
    public class StudentsController : Controller
    {
        private WorkDataContext _workDataContext;
        private IViewModelFactory _viewModelFactory;

        public StudentsController(WorkDataContext workDataContext, IViewModelFactory viewModelFactory){

            _workDataContext = workDataContext;
            _viewModelFactory = viewModelFactory;
        }

        public IActionResult Index()
        {
            return View(_viewModelFactory.CreateStudents(_workDataContext.WorkItems));
        }

        public IActionResult Details(int id){

            var studentWorkItems = _workDataContext.WorkItems.Where(i => i.UserId == id);

            if(!studentWorkItems.Any())
                return NotFound();
                
            var studentWork = _viewModelFactory.CreateStudentWork(studentWorkItems);

            return View(studentWork);
        }
    }
}