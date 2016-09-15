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
    public class ClassController : Controller
    {
        private IClassRepository ClassRepository { get; set; }

        public ClassController(IClassRepository classRepository)
        {
            ClassRepository = classRepository;
        }

        [HttpGet]
        [Route("{id}/currentActivity")]
        public async Task<IEnumerable<Model.DTO.ProgressPerUser>> ListCurrentActivity(int id)
        {
            return await ClassRepository.GetCurrentActivity(id);
        }


        [HttpGet]
        public async Task<IEnumerable<Class>> Get()
        {
            return await ClassRepository.List();
        }

        [HttpGet]
        [Route("subjects")]
        public async Task<IEnumerable<string>> ListSubjects()
        {
            return await ClassRepository.ListSubjects();
        }

        [HttpGet]
        [Route("domains")]
        public async Task<IEnumerable<string>> ListDomains()
        {
            return await ClassRepository.ListDomains();
        }

        [HttpGet]
        [Route("objectives")]
        public async Task<IEnumerable<string>> ListLearningObjectives()
        {
            return await ClassRepository.ListLearningObjectives();
        }
    }
}
