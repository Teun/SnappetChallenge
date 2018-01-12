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
        public const string DATE_FORMAT = "dd'/'MM'/'yyyy";
        IWorkRepository workRepo;
        IReportService reportService;
        public WorkController(IWorkRepository _workRepo, IReportService _reportService)
        {
            workRepo = _workRepo;
            reportService = _reportService;
        }

        // GET api/Work           
        public IEnumerable<Work> Get()
        {
            var works = workRepo.GetAll().Take(10);
            return works.ToList();
        }

        //// GET api/Work/5        
        //public Work Get(int id)
        //{
        //    var work  = workRepo.Get(id);
        //    return work;
        //}

        // GET api/Work/{date}   
        public IEnumerable<LearningObjectiveProgress> Get(string dateVal)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            //DateTime date = DateTime.ParseExact(dateVal, "mm/dd/yyyy", provider);

            DateTime date1 = Convert.ToDateTime(dateVal,provider);

            var work = reportService.GetLearningObjectiveProgressReport(date1);
            return work;
        }
    }
}
