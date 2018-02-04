namespace SnappetChallenge.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using SnappetChallenge.WebApi.Helpers;
    using SnappetChallenge.WebApi.Models;

    [Route("api/[controller]")]
    public class StudentsWorkingResultController : Controller
    {
        private readonly IFileRepository<ExerciseResultJsonDeserializeModel> repository;

        public StudentsWorkingResultController(IFileRepository<ExerciseResultJsonDeserializeModel> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("from/{from}/to/{to}")]
        public IActionResult Get([FromRoute] DateTime from, [FromRoute] DateTime to)
        {
            try
            {
                IEnumerable<StudentResultModel> result = this.repository.GetGroupedListByData(from, to);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex);
            }
        }
    }
}
