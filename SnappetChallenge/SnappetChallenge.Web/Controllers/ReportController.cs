namespace SnappetChallenge.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using EFGetStarted.AspNetCore.NewDb.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SnappetChallenge.Core;

    /// <summary>
    /// Report controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Produces("application/json")]
    [Route("api/v1/Report")]
    public class ReportController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ClassReportContext reportContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ReportController(ClassReportContext context)
        {
            this.reportContext = context;
        }

        /// <summary>
        /// Gets the report items. Try it /api/v1/Report?date=2015-03-02
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Action result</returns>
        [HttpGet]
        public async Task<IActionResult> GetReportItems([FromQuery(Name = "date")]DateTime? date)
        {
            return await this.GetReportItemsProxy(
                date, 
                async () =>
                {
                    var repItems = await new ReportDatabaseLayer(this.reportContext).GetReportItemAsync(date);
                    if (repItems?.Count == 0)
                    {
                        throw new ResultNotFoundException();
                    }

                    return Ok(new ApiResponse<ApiReportItem>()
                    {
                        Code = StatusCodes.Status200OK,
                        ItemsCount = repItems.Count,
                        LessonDate = date,
                        ReportItems = repItems
                    });
                });
        }

        /// <summary>
        /// Gets the report items proxy.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="action">The action.</param>
        /// <returns>Action result</returns>
        private async Task<IActionResult> GetReportItemsProxy(DateTime? date, Func<Task<IActionResult>> action)
        {
            try
            {
                return await action.Invoke();
            }
            catch (ResultNotFoundException)
            {
                return this.NotFound(new ApiResponse<ApiReportItem>()
                {
                    Code = StatusCodes.Status404NotFound,
                    LessonDate = date
                });
            }
            catch (Exception e)
            {
                return this.BadRequest(new ApiResponse<ApiReportItem>()
                {
                    Code = StatusCodes.Status400BadRequest,
                    LessonDate = date,
                    ErrorMsg = e.Message
                });
            }
        }
    }
}