using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using SnappetChallenge.BusinessLogicLayer.BusinessObjects;
using SnappetChallenge.BusinessLogicLayer.Interfaces;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    [Authorize]
    public class SubmittedAnswerController : Controller
    {
        private readonly ISubmittedAnswerService _submittedAnswerService;
        private readonly IMapper _autoMapper;

        public SubmittedAnswerController(ISubmittedAnswerService submittedAnswerService, IMapper autoMapper)
        {
            if (submittedAnswerService == null) throw new ArgumentNullException(nameof(submittedAnswerService));
            if (autoMapper == null) throw new ArgumentNullException(nameof(autoMapper));

            _submittedAnswerService = submittedAnswerService;
            _autoMapper = autoMapper;
        }

        // GET: SubmittedAnswer
        public ActionResult Index()
        {
            var submittedAnswerList = _submittedAnswerService.GetSubmittedAnswers();
            var submittedAnswerViewModelList = submittedAnswerList
                .Select(_autoMapper.Map<SubmittedAnswerViewModel>)
                .ToList();

            var model = new SubmittedAnswerListViewModel()
            {
                Answers = submittedAnswerViewModelList.AsQueryable()
            };
            return View(model);
        }
    }
}