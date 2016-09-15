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
    }
}
