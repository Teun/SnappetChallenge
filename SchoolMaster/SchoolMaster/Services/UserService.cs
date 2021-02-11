using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SchoolMaster.Database.Repositories;
using SchoolMaster.Models.DataTransferObjects;

namespace SchoolMaster.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var users = await _userRepository.GetAllUsersAsync(cancellationToken);
            return _mapper.Map<ICollection<UserDto>>(users);
        }
    }
}