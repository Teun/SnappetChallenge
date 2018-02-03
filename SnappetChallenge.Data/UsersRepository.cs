using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Data
{
    public class UsersRepository : IUsersRepository
    {
        public IQueryable<UserDb> Query()
        {
            using (var contentStream = File.OpenRead("users.json"))
            {
                using (var streamReader = new StreamReader(contentStream))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<IEnumerable<UserDb>>(
                        new JsonTextReader(streamReader)).AsQueryable();
                }
            }
        }
    }
}