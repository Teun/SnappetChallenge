using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Builders;
using SnappetChallenge.Core;
using SnappetChallenge.Models;

namespace SnappetChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly ILearningObjectiveSubmittedAnswersFilterBuilder filterBuilder;
        private readonly IUsersProvider usersProvider;
        private readonly IUserDtoBuilder userDtoBuilder;
        private readonly IUserSubmittedAnswersFilterBuilder userSubmittedAnswersFilterBuilder;
        private readonly IUserDetailsDtoBuilder userDetailsDtoBuilder;

        public UserController(ILearningObjectiveSubmittedAnswersFilterBuilder filterBuilder,
            IUsersProvider usersProvider,
            IUserDtoBuilder userDtoBuilder,
            IUserSubmittedAnswersFilterBuilder userSubmittedAnswersFilterBuilder,
            IUserDetailsDtoBuilder userDetailsDtoBuilder)
        {
            this.filterBuilder = filterBuilder;
            this.usersProvider = usersProvider;
            this.userDtoBuilder = userDtoBuilder;
            this.userSubmittedAnswersFilterBuilder = userSubmittedAnswersFilterBuilder;
            this.userDetailsDtoBuilder = userDetailsDtoBuilder;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<UserDto> GetUsers([FromQuery] DateRangeFilterDto filter)
        {
            var internalFitler = filterBuilder.Build(filter);
            var users = usersProvider.GetUsers(internalFitler);
            var result = users.Select(userDtoBuilder.Build)
                .OrderBy(u => u.Name)
                .ToArray();
            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public UserDetailsDto GetUserDetails([FromRoute]int id, [FromQuery] DateRangeFilterDto filter)
        {
            var internalFilter = userSubmittedAnswersFilterBuilder.Build(filter, id);
            var user = usersProvider.GetUsers(internalFilter)
                .FirstOrDefault();
            if (user == null)
                throw new HttpResponseException($"User with id {id} was not found.", 404);
            return userDetailsDtoBuilder.Build(user);
        }
    }
}