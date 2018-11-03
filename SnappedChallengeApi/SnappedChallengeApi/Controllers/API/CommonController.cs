using Microsoft.AspNetCore.Mvc;
using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Controllers.API.Base;
using SnappedChallengeApi.Services.Implementations;
using SnappedChallengeApi.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Net;

namespace SnappedChallengeApi.Controllers.API
{
    public class CommonController : BaseController
    {

        private CommonService _service = null;

        public CommonController(ICommonService commonService)
        {
            if (commonService.IsNullOrEmpty())
                throw new Exception(nameof(commonService));

            _service = (CommonService)commonService;
        }

        /// <summary>
        /// Service health check api
        /// </summary>
        /// <returns></returns>
        //[SwaggerGroup("Others")]
        [HttpPost]
        [Route("ping")]
        [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, description: "no response")]
        public IActionResult Ping()
        {
            return Ok(_service.Ping());
        }
    }
}
