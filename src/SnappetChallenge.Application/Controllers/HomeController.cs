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
            var result = await _mediator.Send(new GetWorksForDateRequest { InitialDate = new DateTime(2015, 3, 24, 0, 0, 0), FinalDate = new DateTime(2015, 3, 24, 11, 30, 00) });

            return View(result);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
