using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        // GET api/work/01-01-2018T15:00:00
        [HttpGet("{subject}/{date}")]
        public ActionResult<IEnumerable<WorkItem>> Get(string subject, DateTime date)
        {
            var begin = date.Date;
            var end = date.AddDays(1).AddSeconds(-1); ;

            var workItems = Program.WorkItems.Where(x => x.Subject == subject && x.SubmitDateTime >= begin && x.SubmitDateTime <= end);

            return workItems.OrderBy(x => x.SubmitDateTime).ToArray();
        }

        // GET api/work/subjects/01-01-2018T15:00:00
        [HttpGet("subjects/{date}")]
        public ActionResult<IEnumerable<string>> Subjects(DateTime date)
        {
            var begin = date.Date;
            var end = date.AddDays(1).AddSeconds(-1);

            var subjects = Program.WorkItems.Where(x => x.SubmitDateTime >= begin && x.SubmitDateTime <= end).Select(x => x.Subject).Distinct();

            return subjects.OrderBy(x => x).ToArray();
        }
    }
}
