namespace SnappedChallengeApi.Controllers.API.Base
{
    using Microsoft.AspNetCore.Mvc;
    using SnappedChallengeApi._Corelib.Extensions;
    using SnappedChallengeApi.Models.Commons.ApiCommons;
    using SnappedChallengeApi.Models.Constants;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Net;

    /// <summary>
    /// A base controller that is being used for common operations and common method needs for all of the api controllers
    /// basic needs will be coded here to help inherited controllers.
    /// </summary>
    [Route("api")]
    [ApiExplorerSettings(IgnoreApi = false)]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    [SwaggerResponse((int)HttpStatusCode.BadRequest)]
    [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
    [Produces(ServiceConstants.ApplicationJsonContent)]
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Query string parser method required when restful client calls with query string
        /// </summary>
        /// <param name="defaultRecordCount"></param>
        /// <returns></returns>
        internal QueryParameter ParseQueryString(int? defaultRecordCount = 25)
        {
            try
            {
                return HttpContext.ParseQueryString(defaultRecordCount);
            }
            catch (Exception ex)
            {
                //TODO log
                throw ex;
            }
        }
    }
}
