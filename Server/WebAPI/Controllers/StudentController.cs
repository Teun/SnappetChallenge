using Contract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using WebAPI.Unity;
using WebAPI.Models;

namespace WebAPI.Controllers
{
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
        public IEnumerable<Student> get()
        {
            //UnityConfigurations._container.Resolve<IStudentFacade>().GetStudent("print");
            StudentService.GetStudent("print");
            return students;
        }

        [HttpGet]
        public IHttpActionResult get(int id)
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
