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
    public class LearningObjectiveController : Controller
    {
        private ILearningObjectiveRepository LearningObjectiveRepository { get; set; }

        public LearningObjectiveController(ILearningObjectiveRepository learningObjectiveRepository)
        {
            LearningObjectiveRepository = learningObjectiveRepository;
        }

        [HttpGet]
        [Route("{classId}/{userId}")]
        public async Task<IEnumerable<Model.DTO.ProgressPerLearningObjective>> ListCurrentActivity(int classId, int userId)
        {
            return await LearningObjectiveRepository.GetProgress(classId, userId);
        }
    }
}
