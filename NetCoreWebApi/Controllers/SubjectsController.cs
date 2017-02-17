using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnappetWorkApp.Services;

namespace SnappetWorkApp
{
    public class SubjectsController : Controller
    {
        private WorkDataContext _workDataContext;
        private IViewModelFactory _viewModelFactory;

        public SubjectsController(WorkDataContext workDataContext, IViewModelFactory viewModelFactory){

            _workDataContext = workDataContext;
            _viewModelFactory = viewModelFactory;
        }

        public IActionResult Details(int studentId, string name){

            var subjectWorkItems = _workDataContext.WorkItems.Where(i => i.UserId == studentId &&  i.Subject == name);

            var subjectViewModel = _viewModelFactory.CreateSubjectViewModel(subjectWorkItems);

            return View(subjectViewModel);
        }
    }
}