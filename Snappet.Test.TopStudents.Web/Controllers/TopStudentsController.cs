using System;
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
    [RoutePrefix("top-students/api")]
    public class TopStudentsController : ApiController
    {
        private readonly ITopStudentsQuery _topStudentsQuery;

        public TopStudentsController(ITopStudentsQuery topStudentsQuery)
        {
            _topStudentsQuery = topStudentsQuery;
        }

        /// <summary>
        /// Subjects:
        /// Begrijpend Lezen
        /// Spelling
        /// Rekenen
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        [Route("subjects/{subject}/{year}/{month}/{day}")]
        [ResponseType(typeof(TopStudentsRecord))]
        public async Task<IHttpActionResult> GetDay(string subject, int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var record = await _topStudentsQuery.GetAsync(subject, TopStudentsRecordTypes.Day, date);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }
        
        [Route("subjects/{subject}/{year}/{month}")]
        [ResponseType(typeof(TopStudentsRecord))]
        public async Task<IHttpActionResult> GetMonth(string subject, int year, int month)
        {
            var date = new DateTime(year, month, 1);
            var record = await _topStudentsQuery.GetAsync(subject, TopStudentsRecordTypes.Month, date);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

      
    }
}
