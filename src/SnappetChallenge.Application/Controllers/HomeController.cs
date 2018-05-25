using MediatR;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Application.Models;
using SnappetChallenge.Application.Requests;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SnappetChallenge.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetWorksForDateRequest { InitialDate = new DateTime(2015, 3, 23, 0, 0, 0), FinalDate = new DateTime(2015, 3, 23, 23,59, 59) });
            
            return View(result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
