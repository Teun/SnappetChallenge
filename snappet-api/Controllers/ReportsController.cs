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
        public List<DateTime> GetAvailableDates()
        {
            return _classMethods.GetAvailableDates();
        }

        [HttpGet]
        public List<LearningObjectiveVM> ClassReport(string date)
        {
            if (date == "null")
            {
                return new List<LearningObjectiveVM>();
            }
            return _classMethods.GetClassReport(Convert.ToDateTime(date), null);
        }

        [HttpGet]
        public List<LearningObjectiveVM> WeekReport(int Weeks = 1)
        {
            return _classMethods.GetWeekReport(Weeks);
        }
    }
}
