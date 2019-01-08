using Snappet.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebAPI.Models;

namespace Snappet.WebAPI.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        Student[] students = new Student[]
        {
            new Student { Id = 1, Name = "Tomato Soup" },
            new Student { Id = 2, Name = "Yo-yo" },
            new Student { Id = 3, Name = "Hammer" }
        };

        private IStudentFacade StudentService;
        public StudentController(IStudentFacade StudentService)
        {
            this.StudentService = StudentService;
        }
        [HttpGet]
       [Route("Get")]
        public IEnumerable<Student> get()
        {
            
            StudentService.GetStudent("print");
            return students;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult get([FromUri]int id)
        {
            var product = students.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
