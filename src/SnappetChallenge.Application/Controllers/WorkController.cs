using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.Application.Controllers
{
    public class WorkController : Controller
    {
        private readonly IMediator _mediator;
        public WorkController(IMediator mediator)
        {
            _mediator = mediator;
        }


    }
}
