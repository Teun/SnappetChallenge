using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snappet.Logic.Database;
using Snappet.Models.Database.StoredProcedures.Rep;
using System.Threading.Tasks;

namespace Snappet.API.Controllers.Rep
{
    [Route("/api/Rep/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]      //Only teachers could get these reports.
    public class SubmittedAnswersController : BaseController
    {
        private readonly IDatabaseContext _dbCTX;


        public SubmittedAnswersController(IDatabaseContext dbCTX)
        {
            _dbCTX = dbCTX;
        }

        /// <summary>
        /// What has my class been working on today?
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ClassProgressAsync([FromQuery] SP_Class_Progress.Inputs inputs)
        {
            Models.Database.DBResult rst = null;
            await Task.Run(() =>
            {
                rst = _dbCTX.SP_Class_Progress(inputs);
            });

            return FromDatabase(rst);
        }


        /// <summary>
        /// Report careless students group by domain during a certain datetime
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CarelessStudentsAsync([FromQuery] SP_SubmittedAnswers_CarelessStudents.Inputs inputs)
        {
            Models.Database.DBResult rst = null;
            await Task.Run(() =>
            {
                rst = _dbCTX.SP_SubmittedAnswers_CarelessStudents(inputs);
            });

            return FromDatabase(rst);
        }
    }
}
