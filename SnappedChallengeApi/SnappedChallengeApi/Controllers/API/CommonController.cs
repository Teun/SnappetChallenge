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
    /// <summary>
    /// Common controller that is used for the common operations like health check etc.
    /// </summary>
    public class CommonController : BaseController
    {
        /// <summary>
        /// Common service instance
        /// </summary>

        private CommonService _service = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commonService"></param>
        public CommonController(ICommonService commonService)
        {
            if (commonService.IsNullOrEmpty())
                throw new Exception(nameof(commonService));

            _service = (CommonService)commonService;
        }

        /// <summary>
        /// Service health ping check api
        /// </summary>
        /// <returns></returns>
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
