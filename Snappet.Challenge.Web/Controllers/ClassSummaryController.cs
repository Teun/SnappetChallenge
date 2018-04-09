using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Snappet.Challenge.Web.Core.ViewModel;
using Snappet.Challenge.Web.Helpers;
using Snappet.Challenge.Web.Repositories;

namespace Snappet.Challenge.Web.Controllers
{
    public class ClassSummaryController : Controller
    {
        private readonly IClassRepository _classRepository;
        private const int PageSize = 20;
        
        public ClassSummaryController(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Index(new DateTime().NowAtSnappet());
        }

        [HttpPost]
        public IActionResult Index([FromForm] ClassSummaryViewModel classSummaryViewModel)
        {
            return Index(classSummaryViewModel.SearchDate);
        }
        
        private IActionResult Index(DateTime date)
        {
            var result = GetUserWorkSummarizedByDate(date);
            if (result == null)
                return RedirectToAction("NoData");

            result.SearchDate = date;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int id, int? pageIndex)
        {
            ViewBag.Title = $"Answers submitted by user {id}";
            
            pageIndex = pageIndex ?? 1;
            var workList = _classRepository.GetWorkByUser(id, pageIndex.Value, (PageSize) + 1);
            var detailsViewModel = new DetailsViewModel
            {
                WorkList = workList.Take(PageSize),
                PageIndex = pageIndex.Value,
                PageSize = PageSize,
                TotalRecords = workList.Count()
            };
                
            return View(detailsViewModel);
        }
        
        [HttpGet]
        public IActionResult NoData()
        {
            return View();
        }

        private ClassSummaryViewModel GetUserWorkSummarizedByDate(DateTime searchDate)
        {
            var workList = _classRepository.GetUserWorkSummarizedByDate(searchDate).ToList();
            if (workList.Count == 0)
                return null;
                
            var classSummary = _classRepository.GetAllWorkSummirazedByDate(searchDate);
            
            return new ClassSummaryViewModel
            {
                ClassSummary =  classSummary,
                ClassResults = workList,
                TopStudent = workList.First(),
                SearchDate = searchDate
            };
        }
    }
}