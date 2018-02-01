using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappetChallenge.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    
    [Route("api/[controller]")]
    public class ClassResultController : Controller
    {
        public ClassResultController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok();
        }
    }
}
