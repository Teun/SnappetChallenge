using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Snappet.API.Controllers.dbo
{
    [Route("/api/dbo/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly Logic.Database.IDatabaseContext _dbCTX;
        private readonly IMapper _mapper;

        public TeachersController(
            Logic.Database.IDatabaseContext dbCTX,
            IMapper mapper)
        {
            _dbCTX = dbCTX;
            _mapper = mapper;
        }

        /// <summary>
        /// Authenticate teacher info
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] Logic.Security.Teacher teacher)
        {
            var rst = teacher.Login(_dbCTX, _mapper, "This is a key for testing JWT in the snappetCodeChallenge", "https://snappet.org/");
            return Ok(rst);
        }
    }
}
