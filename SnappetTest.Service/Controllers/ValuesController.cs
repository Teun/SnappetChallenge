using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SnappetTest.Service.ViewModels;
using SnappetTest.Service.Infrastructure.Abstract;
using System.Collections.Generic;

using System;


namespace SnappetTest.Service.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFetchAnswerCountProvider _answerCount;
        private readonly IFetchCorrectAnswerCountProvider _correctAnswerCount;
        private readonly IFetchProgressProvider _progress;
        private readonly IFetchRequestedDateProvider _requestedDate;
        private readonly IFetchSubjectProvider _subject;
        public ValuesController(IMapper mapper, IFetchAnswerCountProvider answerCount, IFetchCorrectAnswerCountProvider correctAnswer,
            IFetchProgressProvider progress, IFetchRequestedDateProvider requestedDate, IFetchSubjectProvider subject )
        {
            _mapper = mapper;
            _answerCount = answerCount;
            _correctAnswerCount = correctAnswer;
            _progress = progress;
            _requestedDate = requestedDate;
            _subject = subject;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {

            var result = new SnappetViewModel
            {
                AnswersCount = _mapper.Map<SnappetViewModel>(_answerCount).AnswersCount,
                CorrectAnswersCount = _mapper.Map<SnappetViewModel>(_correctAnswerCount).CorrectAnswersCount,
                ProgessCount = _mapper.Map<SnappetViewModel>(_progress).ProgessCount,
                DateRequested = _mapper.Map<SnappetViewModel>(_requestedDate).DateRequested,
                Subject = _mapper.Map<SnappetViewModel>(_subject).Subject
               
            };

            return Json(result);
        }

      

    }
}
