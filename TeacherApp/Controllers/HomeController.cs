using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeacherApp.Models;
using TeacherApp.Models.ViewModels;

namespace TeacherApp.Controllers
{
    // GET: /
    public class HomeController : Controller
    {
        private ITeacherAppRepository repository;
        private const string toDate = "2015-03-24 11:30:00";
		private DateTime toDateUtc = DateTimeOffset.Parse(toDate).UtcDateTime;

		private int PageSize = 5;

        // GET: /
        public HomeController(ITeacherAppRepository repo)
        {
            repository = repo;
        }

        // Setup pagination.
        public ViewResult Index(int studentPage = 1)
            => View(new StudentListViewModel
            {
                Students = repository.Students
                    .OrderBy(s => s.StudentId)
                    .Skip((studentPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = studentPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Students.Count()
                }
            });

		// GET: /students/
		[HttpGet("students")]
		public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await repository.Students.OrderBy(s => s.StudentId).ToListAsync();
            return Ok(students);
        }

		// GET: /students/{studentId}/
		[HttpGet("students/{studentId}")]
        public async Task<ActionResult<List<Work>>> GetStudentWork(int studentId)
        {
            var studentWork = await repository.Works
                .Where(w => w.UserId == studentId && w.SubmitDateTime >= toDateUtc)
                .ToListAsync();
            return Ok(studentWork);
        }

		// GET: /subjects/
		[HttpGet("subjects")]
		public async Task<ActionResult<List<string>>> GetSubjects()
		{
			var subjects = await repository.Works
                .Where(w => w.SubmitDateTime >= toDateUtc)
                .GroupBy(w => w.Subject)
                .Select(group => group.First().Subject)
                .ToListAsync();
			return Ok(subjects);
		}


        // POST: /learningObjectives/
        [HttpPost("learningobjectives")]
        public async Task<ActionResult<List<string>>> GetLearningObjectives([FromBody] string subject)
        {
            var learningObjectives = await repository.Works
                .Where(w => w.SubmitDateTime >= toDateUtc && w.Subject == subject)
                .GroupBy(w => w.LearningObjective)
                .Select(group => group.First().LearningObjective)
                .ToListAsync();
            return Ok(learningObjectives);
        }


		// POST: /subjects/
		[HttpPost("worksbysubject")]
		public async Task<ActionResult<List<Work>>> GetWorkBySubject([FromBody] WorksBySubjectViewModel category)
		{
			var workBySubject = await repository.Works
				.Where(w => category.subject == null || category.subject == w.Subject)
                .Where(w => category.learningObjective == null || category.learningObjective == w.LearningObjective)
                .Where(w => w.SubmitDateTime >= toDateUtc)
				.ToListAsync();
			return Ok(workBySubject);
		}
	}
}
