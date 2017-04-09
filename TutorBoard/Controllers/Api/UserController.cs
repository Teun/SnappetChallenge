using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TutorBoard.Dal.Models;
using TutorBoard.Dal.Repositories;

namespace TutorBoard.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepo;
        
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: /api/User
        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepo.GetAsync();
        }


        // GET: /api/User/{id}
        public async Task<User> Get(int id)
        {
            return await _userRepo.GetOneAsync(id);
        }
    }
}
