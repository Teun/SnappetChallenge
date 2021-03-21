using Microsoft.AspNetCore.Mvc;

namespace Snappet.API.Controllers
{
    /// <summary>
    /// All controllers will be inherited from this class.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Convert database result to rest standard result based on the status code and dbResult
        /// </summary>
        /// <param name="dbResult"></param>
        /// <returns></returns>
        protected IActionResult FromDatabase(Models.Database.DBResult dbResult)
        {
            if (dbResult == null)
                return StatusCode(500, "Unhandled internal server error");

            if (dbResult.StatusCode >= 200 && dbResult.StatusCode < 300)
                return StatusCode(dbResult.StatusCode, dbResult);

            return StatusCode(dbResult.StatusCode, dbResult.ErrorMessage ?? "Unhandled error");
        }
    }
}
