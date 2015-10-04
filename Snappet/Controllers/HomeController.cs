using System.Collections.Generic;
using System.Linq;
using Snappet.Domain;
using System.Web.Mvc;
using Snappet.Domain.Contracts;
using Snappet.Models;

namespace Snappet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExerciseResultService _exerciseResultService;
        public HomeController(IExerciseResultService exerciseResultService) {
            _exerciseResultService = exerciseResultService;
        }

        public ActionResult Index()
        {
            var newModel = new Models.DashboardViewModel()
            {
                Domains = _exerciseResultService.GetDomains(),
                Subjects = _exerciseResultService.GetSubjects(),
            };
            foreach (var domain in newModel.Domains)
            {
                domain.Users = _exerciseResultService.GetUsers(domain.Id);
            }
            return View(newModel);
        }


        public JsonResult GetExerciseResults(int domainId,int userId, List<ColumnViewModel> columns, int draw, int length, OrderViewModel[] order, SearchviewModel search, int start)
        {
            var orderByColumn = columns[order[0].column];
            var searchModel = new DataTableSearch()
            {
                DomainId = domainId,
                UserId = userId,
                Page = start == 0 ? start : (start / length),
                Length = length,
                Search = search.value,
                Order = new ColumnOrder() { ColumnName = orderByColumn.data, Order = order[0].dir }
            };
            var searchResults = _exerciseResultService.GetExerciseResults(searchModel);
            var logCount = _exerciseResultService.GetExerciseResultCount(domainId,userId ,search.value);
            var logArray =
                searchResults.Select(
                    x => new { x.Id, UserId = x.UserId.ToString(), x.Subject,
                         x.LearningObjective,
                        x.ExerciseId,
                        x.SubmittedAnswerId,
                        Correct = x.Correct? "<span class='glyphicon glyphicon-ok' aria-hidden='true'></span>":
                        "<span class='glyphicon glyphicon-remove' aria-hidden='true'></span>",
                        SubmitDateTime = x.SubmitDateTime.ToShortTimeString(),
                        Progress =x.Progress.ToString() + (x.Progress<0 ? " <span class='glyphicon glyphicon-hand-down' aria-hidden='true'></span>" : x.Progress==0?
                        " <span class='glyphicon glyphicon-hand-right' aria-hidden='true'></span>" 
                        :" <span class='glyphicon glyphicon-hand-up' aria-hidden='true'></span>"),
                        x.Difficulty
                    });
            return Json(new { aaData = logArray, recordsTotal = logCount, recordsFiltered = logCount, draw = draw }, JsonRequestBehavior.AllowGet);

        }


    }

    
}