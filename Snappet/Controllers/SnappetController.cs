using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SnappetDomain.Models;
using SnappetDomain.Services;

namespace Snappet.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SnappetController : Controller
    {
        private readonly ISnappetService _service;

        public SnappetController(ISnappetService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<LearningSubject> GetByDate([Required][FromQuery]DateTime maxDateTime)
            => _service.GetByDate(maxDateTime);
    }
}