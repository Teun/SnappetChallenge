using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using snappet.core.Contracts;
using snappet.core.Implementation;
using snappet.core.Models.ViewModels;

namespace snappet_api.Controllers
{
    public class ReportsController : ApiController
    {
        private readonly IClassMethods _classMethods;

        public ReportsController()
        {
            _classMethods = new ClassMethods();
        }

        [HttpGet]
        public List<SubjectVM> GetAvailableSubjects()
        {
            return _classMethods.GetAvailableSubjects();
        }

        [HttpGet]
        public List<string> GetAvailableDates()
        {
            return _classMethods.GetAvailableDates();
        }

        [HttpGet]
        public List<SubmittedAnswerVM> DayReportBySubject(int SubjectID, string date)
        {
            if (date == "null")
            {
                return new List<SubmittedAnswerVM>();
            }
            return _classMethods.GetDayReportBySubject(SubjectID, Convert.ToDateTime(date), null);
        }

        [HttpGet]
        public List<SubmittedAnswerVM> WeekReportBySubject(int SubjectID, int Weeks = 1)
        {
            return _classMethods.GetWeekReportBySubject(SubjectID, Weeks);
        }


        [HttpGet]
        public List<LearningObjectiveVM> DayReportByLO(string date)
        {
            if (date == "null")
            {
                return new List<LearningObjectiveVM>();
            }
            return _classMethods.GetDayReportByLO(Convert.ToDateTime(date), null);
        }

        [HttpGet]
        public List<LearningObjectiveVM> WeekReportByLO(int Weeks = 1)
        {
            return _classMethods.GetWeekReportByLO(Weeks);
        }
    }
}
