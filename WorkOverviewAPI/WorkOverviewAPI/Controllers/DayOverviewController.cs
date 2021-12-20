using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOverviewAPI.Services.Interfaces;

namespace WorkOverviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOverviewController : ControllerBase
    {
        private IDayOverviewService _dayOverviewService;
        public DayOverviewController(IDayOverviewService dayOverviewService) {
            _dayOverviewService = dayOverviewService;

        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult getDayOveriewById(int id)
        {
            try {
                var model = _dayOverviewService.getById(id);
                return Ok(model);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("getByDate/{tillDateTime}")]
        public IActionResult getDayOveriewByDate(DateTime tillDateTime)
        {
            try
            {
                var model = _dayOverviewService.getByDate(tillDateTime);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }


}
