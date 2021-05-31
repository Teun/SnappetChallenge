using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet.Model;
using Snappet.Service;

namespace Snappet.Controllers
{
    [ApiController]
    [Route("AutoComplete")]
    public class AutoCompleteController : ControllerBase
    {
        private readonly ISubmittedAnswerService _submittedAnswerService;

        public AutoCompleteController(ISubmittedAnswerService submittedAnswerService)
        {
            _submittedAnswerService = submittedAnswerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AutoCompleteResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> Get([FromQuery] AutoCompleteRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _submittedAnswerService.AutoComplete(request.Keyword, request.Count, request.Type);
            return Ok(new AutoCompleteResponse
            {
                Items = result.ToArray()
            });
        }
    }
}