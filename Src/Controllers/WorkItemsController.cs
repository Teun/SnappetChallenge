using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsAPI.WebApi.DTOs;
using StudentsAPI.WebApi.Services;

namespace StudentsAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WorkItemsController : Controller
    {
        private readonly ILogger<WorkItemsController> _logger;
        private readonly IWorkItemService _service;
        public WorkItemsController(ILogger<WorkItemsController> logger, IWorkItemService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetWorkItemsDTO dto)
        {
            try
            {
                var items = await _service.GetWorkItemsAsync(dto);
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
