using Microsoft.AspNetCore.Mvc;
using WorkDataService;
using System.Linq;
using System;

public class WorkController : Controller
{
    private WorkDataContext _workDataContext;

    public WorkController(WorkDataContext workDataContext){

       _workDataContext = workDataContext;
    }

    public IActionResult Report()
    {
        return View();
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