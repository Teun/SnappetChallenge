using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snappet.Repository.Interfaces;
using Snappet.Model;

namespace Snappet.Web.Controllers
{
    [Route("api/[controller]")]
    public class AnswerController : Controller
    {
        private IAnswerRepository AnswerRepository { get; set; }

        public AnswerController(IAnswerRepository answerRepository)
        {
            AnswerRepository = answerRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            AnswerRepository.Add(new Answer()
            {
                Correct = true,
                Difficulty = 1.2,
                Domain = "dom",
                ExerciseId = 1,
                LearningObjective = "obj",
                Progress = 20,
                Subject = "sub",
                SubmitDateTime = DateTime.Now
                //SubmittedAnswerId = 22
            });

            AnswerRepository.Save();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
