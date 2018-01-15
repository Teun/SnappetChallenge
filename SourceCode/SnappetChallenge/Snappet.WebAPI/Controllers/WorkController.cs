using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Snappet.WebAPI.Core.Repositories;
using Snappet.WebAPI.Persistence.Repositories;
using Snappet.WebAPI.Models;
using Snappet.WebAPI.Persistence;
using System.Globalization;

namespace Snappet.WebAPI.Controllers
{
    public class WorkController : ApiController
    {
        IWorkRepository workRepo;
        IReportService reportService;
        public WorkController(IWorkRepository _workRepo, IReportService _reportService)
        {
            workRepo = _workRepo;
            reportService = _reportService;
        }
      
        // GET api/Work/{date}   
        public IEnumerable<LearningObjectiveProgress> Get(string dateVal)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime date = Convert.ToDateTime(dateVal, provider);

            var work = reportService.GetLearningObjectiveProgressReport(date);
            return work;
        }
        
    }
}
