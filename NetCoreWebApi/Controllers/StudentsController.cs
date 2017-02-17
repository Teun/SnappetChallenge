using Microsoft.AspNetCore.Mvc;
using WorkDataService;
using System.Linq;
using System;

public class StudentsController : Controller
{
    private WorkDataContext _workDataContext;

    public StudentsController(WorkDataContext workDataContext, IStudentFactory studentFactory){

       _workDataContext = workDataContext;
    }

    public IActionResult Index()
    {

        return View(_workDataContext.WorkItems.Select(i => i.UserId));
    }
}