using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Services.Dto;
using System;

namespace SnappetChallenge.Controllers
{
    public class WorkController : Controller
    {
        private readonly ISubjectService _workService;

        public WorkController(ISubjectService workService)
        {
            _workService = workService;
        }

        [HttpGet("api/work/subjects")]
        public IReadOnlyCollection<Subject> GetSubjects()
        {
            return _workService.GetSubjects();
        }

        [HttpGet("api/work/subjects/{subject}")]
        public SubjectStatistics GetSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }
            return _workService.GetSubject(subject);
        }
    }
}
