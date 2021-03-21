using Microsoft.AspNetCore.Mvc;
using Snappet.Logic.Database;
using Snappet.Models.Database.StoredProcedures.Rep;

namespace Snappet.API.Controllers.Rep
{
    [Route("/api/Rep/[controller]/[action]")]
    [ApiController]
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
        public IActionResult ClassProgress([FromQuery] SP_Class_Progress.Inputs inputs)
        {
            var rst = _dbCTX.SP_Class_Progress(inputs);
            return FromDatabase(rst);
        }

    }
}
