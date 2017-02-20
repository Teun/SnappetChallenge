using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Snappet.Test.TopStudents.Core.Interfaces;
using Snappet.Test.TopStudents.Core.Model;
using Snappet.Test.TopStudents.Interface.Dtos;
using Snappet.Test.TopStudents.Interface.Interfaces;

namespace Snappet.Test.TopStudents.Web.Controllers
{
    [RoutePrefix("day-summary/api")]
    public class DaySummaryController : ApiController
    {
        private readonly IDaySummaryQuery _daySummaryQuery;

        public DaySummaryController(IDaySummaryQuery daySummaryQuery)
        {
            _daySummaryQuery = daySummaryQuery;
        }

        [Route("subjects")]
        [ResponseType(typeof(TopStudentsRecord))]
        public async Task<IHttpActionResult> GetDay()
        {
            List<DaySummaryDto> record = await _daySummaryQuery.GetSummariesAsync();

            return Ok(record);
        }

        [Route("subjects/{year}/{month}/{day}")]
        [ResponseType(typeof(TopStudentsRecord))]
        public async Task<IHttpActionResult> GetDay(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            List<DaySummaryDto> record = await _daySummaryQuery.GetSummariesAsync(date);

            return Ok(record);
        }
        
        [Route("subjects/{subject}/{year}/{month}/{day}")]
        [ResponseType(typeof(TopStudentsRecord))]
        public async Task<IHttpActionResult> GetMonth(string subject, int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var record = await _daySummaryQuery.GetAsync(subject, date);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

      
    }
}
