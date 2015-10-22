
using Snappet.Challenge.Web.ViewModels;
using SnappetChallenge.Services.Contracts;
using System.Web.Mvc;

namespace Snappet.Challenge.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IExerciseService exerciseService;

        public DashboardController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel {ExerciseCount = exerciseService.GetExerciseCount() };
            return View(viewModel);
        }      
    }
}   