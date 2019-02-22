using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsAPI.WebApi.DTOs;
using StudentsAPI.WebApi.Services;

namespace StudentsAPI.WebApi.Controllers
{
    public class ProgressController : Controller
    {
        private readonly ILogger<WorkItemsController> _logger;
        private readonly IProgressService _service;
        public ProgressController(ILogger<WorkItemsController> logger, IProgressService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("api/users/{userId}/progress")]
        public async Task<IActionResult> Get(GetProgressDTO dto, [Required, FromRoute]int userId )
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode((int)HttpStatusCode.BadRequest);

                var items = await _service.GetProgressAsync(userId, dto);
                return Ok(items);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
