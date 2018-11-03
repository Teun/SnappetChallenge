using Microsoft.AspNetCore.Mvc;
using SnappedChallengeApi.Controllers.API.Base;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace SnappedChallengeApi.Controllers.API
{
    public class ServiceController : BaseController
    {


        //[SwaggerGroup("Others")]
        [HttpPost]
        [Route("ping")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        public IActionResult Ping()
        {
            return Ok(true);
        }
    }
}
