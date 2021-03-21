using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Snappet.API.Controllers.dbo
{
    [Route("/api/dbo/[controller]/[action]")]
    [ApiController]
    public class TeachersController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly Logic.Database.IDatabaseContext _dbCTX;
        private readonly IMapper _mapper;


        /// <summary>
        /// JWT key - Saved appsettings.json
        /// </summary>
        private string JWTKey
        {
            get
            {
                var rst = this._configuration.GetValue<string>("JWT:Key");
                return (rst);
            }
        }

        /// <summary>
        /// Read
        /// </summary>
        private string JWTIssuer
        {
            get
            {
                var rst = this._configuration.GetValue<string>("JWT:Issuer");
                return (rst);
            }
        }

        public TeachersController(
            Logic.Database.IDatabaseContext dbCTX,
            IConfiguration configuration,
            IMapper mapper)
        {
            _dbCTX = dbCTX;
            _configuration = configuration;
            _mapper = mapper;
        }

        /// <summary>
        /// Authenticate teacher info
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] Logic.Security.Teacher teacher)
        {
            Models.Database.DBResult rst = null;
            await Task.Run(() =>
            {
                rst = teacher.Login(_dbCTX, _mapper, JWTKey, JWTIssuer);
            });

            return FromDatabase(rst);
        }
    }
}
