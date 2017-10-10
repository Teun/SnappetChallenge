using SnappetChallenge.WebAPI.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace SnappetChallenge.WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private SubmittedAnswerService submittedAnswerService;

        public StudentsController()
        {
            this.submittedAnswerService = new SubmittedAnswerService();
        }

        public IEnumerable<int> GetStudents()
        {
            // Normally you would have this dataset available in a database
            return new int[] { 40281, 40282, 40285, 68421, 40284, 40273, 40278, 40267, 40271, 40276, 40275, 40274, 40272, 40270, 40286, 40277, 40268, 40279, 40280, 40283 };
        }
    }
}