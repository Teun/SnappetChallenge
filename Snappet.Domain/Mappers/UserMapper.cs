using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.DataAccess.Entities;
using Snappet.Domain.Contracts;

namespace Snappet.Domain.Mappers
{
 
    public interface IUserMapper
    {
        List<User> Map(IEnumerable<UserEntity> entities);
        UserEntity Map(User entity);

    }
    public class UserMapper : IUserMapper
    {
        public UserEntity Map(User domain)
        {
            return new UserEntity()
            {
                UserId = domain.UserId
                
            };
        }

        public List<User> Map(IEnumerable<UserEntity> entity)
        {
            var groupedUsers = entity.GroupBy(x => x.UserId);
            var domains= new List<User>();
            foreach (var user in groupedUsers)
            {
                domains.Add(new User()
                {
                    UserId = user.Key,
                    UserResults = user.Select(x=> new UserResult()
                    {
                        SubjectId = x.SubjectId,
                        CorrectAnswers = x.CorrectAnswers,
                        TotalAnswers = x.TotalAnswers
                    }).ToList()
                });
            }
            return domains;
        }
    }
}
