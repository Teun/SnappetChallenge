using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snappet.Logic.Database;
using Snappet.Models.Database.StoredProcedures.Rep;
using System.Threading.Tasks;

namespace Snappet.API.Controllers.Rep
{
    [Route("/api/Rep/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
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

    }
}
