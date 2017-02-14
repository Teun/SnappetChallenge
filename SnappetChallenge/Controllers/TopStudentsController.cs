using AutoMapper;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.Models;
using System;
using System.Web.Mvc;

namespace SnappetChallenge.Controllers
{
    [Authorize]
    public class TopStudentsController : Controller
    {
        private readonly ISubmittedAnswerService _submittedAnswerService;
        private readonly IMapper _autoMapper;
        private readonly int _topStatisticStudentsCount = 7;

        public TopStudentsController(ISubmittedAnswerService submittedAnswerService, IMapper autoMapper)
        {
            if (submittedAnswerService == null) throw new ArgumentNullException(nameof(submittedAnswerService));
            if (autoMapper == null) throw new ArgumentNullException(nameof(autoMapper));

            _submittedAnswerService = submittedAnswerService;
            _autoMapper = autoMapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadTopStudents(string subject)
        {            
            var topStudentStatistic = _submittedAnswerService.GetTopStudentStatistic(_topStatisticStudentsCount, subject);
            var submittedAnswerViewModelList = _autoMapper.Map<TopStudentsViewModel>(topStudentStatistic);

            return View("Index", submittedAnswerViewModelList);
        }
    }
}
