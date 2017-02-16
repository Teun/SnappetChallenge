using Microsoft.AspNetCore.Mvc;
using WorkDataService;
using System.Linq;
using System;

public class HomeController : Controller
{
    private WorkDataContext _workDataContext;

    public HomeController(WorkDataContext workDataContext){

       _workDataContext = workDataContext;
    }

    [Route("api/work")]
    public IActionResult GetAllWork()
    {
        return Ok(_workDataContext.WorkItems.Where(i => i.UserId == 40281 && i.SubmitDateTime.Date == new DateTime(2015, 3, 2)));
    }

    [Route("api/work/{day}")]
    public IActionResult Index()
    {
        return Ok("Hello World from a controller");
    }
}