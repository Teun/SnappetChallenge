using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SnappetServices.Services;

namespace SnappetServices.Controllers
{
    [Route("api/snappet/v1/students")]
    [ApiController]
    public class StudentsV1Controller : ControllerBase
    {
        private readonly IStudentsServices studentService;

        public StudentsV1Controller(IStudentsServices studentService)
        {
            this.studentService = studentService;
        }

        public ActionResult<IEnumerable<string>> GetAll()
        {
            return this.Ok(this.studentService.GetAll());
        }
    }
}