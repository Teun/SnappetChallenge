namespace SnappedChallengeApi.Controllers.API.Base
{
    using Microsoft.AspNetCore.Mvc;
    using SnappedChallengeApi._Corelib.Extensions;
    using SnappedChallengeApi.Models.Commons.ApiCommons;
    using SnappedChallengeApi.Models.Constants;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System;
    using System.Collections.Generic;
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
        //internal Dictionary<string, string> ParseQueryString()
        //{
        //    try
        //    {
        //        Dictionary<string, string> parameters = new Dictionary<string, string>();
        //        foreach (var key in HttpContext.Request.Query.Keys)
        //        {
        //            if (!parameters.ContainsKey(key))
        //            {
        //                parameters.Add(key, HttpContext.Request.Query[key].ToString().Trim());
        //            }
        //        }
        //        return parameters;
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO log
        //        throw ex;
        //    }
        //    finally
        //    {
        //        //TODO log
        //    }
        //}

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
