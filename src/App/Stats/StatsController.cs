namespace App.Users
{
	using Microsoft.AspNetCore.Mvc;
	using App.Exceptions;

	[Route("api/[controller]")]
	public class StatsController : Controller
	{
		private readonly IStatsService _service;

		public StatsController(IStatsService statsService)
		{
			_service = statsService;
		}

		[HttpGet("")]
		public IActionResult GetStats(int startDateIndex)
		{
			try
			{
				return Ok(_service.GetAllUsersStats(startDateIndex));
			}
			catch (ValidationException ex)
			{
				return BadRequest(new { errorMessage = ex.Message });
			}
		}
	}
}
